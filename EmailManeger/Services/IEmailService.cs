using System;
using EmailManeger.Models;

namespace EmailManeger.Services;

public interface IEmailService
{
    Task<List<Email>> GetEmails();
}