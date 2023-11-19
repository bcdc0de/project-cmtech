using System;
using EmailManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }
    }
}