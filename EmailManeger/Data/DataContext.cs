using System;
using Microsoft.EntityFrameworkCore;
using EmailManeger.Models;

namespace EmailManeger.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Email> Emails { get; set; }
}