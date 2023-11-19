using System;
using EmailApi.ApiClients;
using EmailManager.Data;
using EmailManager.Models;

namespace EmailManager.Services
{
    /**public class YahooService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public YahooService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<List<Email>> GetEmails()
        {

            // Implemente a lógica para obter e-mails do Yahoo usando as configurações fornecidas no appsettings.json
            // Exemplo: Use a biblioteca do Yahoo API Client para interagir com a API do Yahoo Mail.
            // Substitua o seguinte código pelo código real de obtenção de e-mails do Yahoo.

            // Lógica para obter e-mails do Yahoo

            // Exemplo fictício:
            var yahooApiClient = new YahooApiClient(_configuration["YahooApiSettings:ClientId"],
                                                    _configuration["YahooApiSettings:ClientSecret"]);

            var messages = await yahooApiClient.GetEmails();

            // Transformar as mensagens em objetos Email
            var emails = messages.Select(message => new Email
            {
                Subject = message.Subject,
                Sender = message.From,
                Recipient = message.To,
                Date = DateTime.Parse(message.Date),
                BodyText = message.Body,
                EmailServer = "Yahoo"
            }).ToList();

            // Salvar e-mails no banco de dados
            _dbContext.Emails.AddRange(emails);
            await _dbContext.SaveChangesAsync();

            return emails;
        }
    }*/
}