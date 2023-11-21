using System;
using emailManeger.Models;
using Microsoft.EntityFrameworkCore;

namespace emailManeger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }
    }
}