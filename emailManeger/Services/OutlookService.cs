using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using EmailManager.ApiClients;
using EmailManager.Data;
using EmailManager.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Graph;

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

                var confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(_configuration["OutlookApiSettings:OutlookClientId"])
                    .WithClientSecret(_configuration["OutlookApiSettings:OutlookClientSecret"])
                    .WithAuthority(new Uri($"https://login.microsoftonline.com/{_configuration["OutlookApiSettings:TenantId"]}/v2.0"))
                    .Build();

                var authResult = await confidentialClientApplication.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" }).ExecuteAsync();

                var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    return Task.CompletedTask;
                }));

                var messages = await graphClient.Me.MailFolders["inbox"].Messages.Request().Top(10).GetAsync();

                var emails = messages?.Select(message => new Email
                {
                    Assunto = message.Subject ?? "No Subject",
                    Remetente = message.From?.EmailAddress?.Address ?? "No Sender",
                    Destinatario = message.ToRecipients?.FirstOrDefault()?.EmailAddress?.Address ?? "No Recipient",
                    Data = message.ReceivedDateTime?.DateTime ?? DateTime.MinValue,
                    CorpoTexto = message.Body?.Content ?? "No Body",
                    ServidorEmail = "Outlook"
                }).ToList() ?? new List<Email>();

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
