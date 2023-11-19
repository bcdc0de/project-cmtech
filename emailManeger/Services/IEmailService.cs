using System;
using EmailManager.Models;

namespace EmailManager.Services
{
    public interface IEmailService
    {
        Task<List<Email>> GetEmails();
    }

}