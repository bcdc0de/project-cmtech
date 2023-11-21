using System;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using EmailManeger.ApiClients;
using EmailManeger.Data;
using EmailManeger.Models;

namespace EmailManeger.Services;

/**
public class GmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _dbContext;

    public GmailService(IConfiguration configuration, ApplicationDbContext dbContext)
    {
        _configuration = configuration;
        _dbContext = dbContext;
    }

    *public async Task<List<Email>> GetEmails()
    {

        // Implemente a lógica para obter e-mails do Gmail usando as configurações fornecidas no appsettings.json
        // Exemplo: Use a biblioteca do Google API Client para interagir com a API do Gmail.
        // Substitua o seguinte código pelo código real de obtenção de e-mails do Gmail.


        // Lógica para obter e-mails do Gmail

        // Exemplo fictício:
        var gmailApiClient = new GmailApiClient(_configuration["GmailApiSettings:ClientId"],
                                                _configuration["GmailApiSettings:ClientSecret"]);

        //var messages = await gmailApiClient.GetMessages();

        // Transformar as mensagens em objetos Email
        var emails = messages.Select(message => new Email
        {
            Subject = message.Subject,
            Sender = message.From,
            Recipient = message.To,
            Date = DateTime.Parse(message.Date),
            BodyText = message.Body,
            EmailServer = "Gmail"
        }).ToList();

        _dbContext.Emails.AddRange(emails);
        await _dbContext.SaveChangesAsync();

        return emails;
    }
}
*/