using System;
using EmailApi.ApiClients;
using EmailManager.Data;
using EmailManager.Models;

namespace EmailManager.Services
{
    public class OutlookService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public OutlookService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<List<Email>> GetEmails()
        {


            // Implemente a lógica para obter e-mails do Outlook usando as configurações fornecidas no appsettings.json
            // Exemplo: Use a biblioteca do Microsoft Graph para interagir com a API do Outlook.
            // Substitua o seguinte código pelo código real de obtenção de e-mails do Outlook.


            // Lógica para obter e-mails do Outlook

            // Exemplo fictício:
            var outlookApiClient = new OutlookApiClient(_configuration["OutlookApiSettings:ClientId"],
                                                        _configuration["OutlookApiSettings:ClientSecret"]);

            var emails = await outlookApiClient.GetEmails();

            _dbContext.Emails.AddRange(emails);
            await _dbContext.SaveChangesAsync();

            return emails;
        }
    }
}