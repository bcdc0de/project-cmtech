using System;
using emailManeger.Models;

namespace emailManeger.Services
{
    public interface IEmailService
    {
        Task<List<Email>> GetEmails();
    }

}