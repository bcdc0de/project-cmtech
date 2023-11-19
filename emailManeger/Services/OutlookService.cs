// Services/OutlookService.cs
using EmailManager.Data;
using EmailManager.Models;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using EmailManager.ApiClients;
using System.Net.Http.Headers;
using System.Linq;

namespace EmailManager.Services
{
    public class OutlookService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        private readonly OutlookApiClient _outlookApiClient;

        public OutlookService(IConfiguration configuration, ApplicationDbContext dbContext, OutlookApiClient outlookApiClient)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _outlookApiClient = outlookApiClient;
        }

        public async Task<List<Email>> GetEmails()
        {
            try
            {
                var authToken = await _outlookApiClient.GetAccessToken();
                var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(requestMessage =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    return Task.CompletedTask;
                }));

                var messages = await graphClient.Me.MailFolders.Inbox.Messages.Request().Top(10).GetAsync();

                var emails = messages.Select(message => new Email
                {
                    Assunto = message.Subject ?? "No Subject",
                    Remetente = message.From?.EmailAddress?.Address ?? "No Sender",
                    Destinatario = message.ToRecipients?.FirstOrDefault()?.EmailAddress?.Address ?? "No Recipient",
                    Data = message.ReceivedDateTime?.DateTime ?? DateTime.MinValue,
                    CorpoTexto = message.Body?.Content ?? "No Body",
                    ServidorEmail = "Outlook"
                }).ToList();

                _dbContext.Emails.AddRange(emails);
                await _dbContext.SaveChangesAsync();

                return emails;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter e-mails do Outlook: {ex.Message}");
            }
        }
    }
}