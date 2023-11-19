using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EmailManager.Services;
using EmailManager.ApiClients;
using EmailManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adicione os serviços necessários aqui, por exemplo:
            services.AddTransient<IEmailService, OutlookService>();
            //services.AddTransient<IEmailService, GmailService>();
            //services.AddTransient<IEmailService, YahooService>();

            // Configurar a autenticação para cada serviço de e-mail
            ConfigureAuthentication(services, "OutlookApiSettings");
            ConfigureAuthentication(services, "GmailApiSettings");
            ConfigureAuthentication(services, "YahooApiSettings");

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmailManager API", Version = "v1" });
            });
        }

        private void ConfigureAuthentication(IServiceCollection services, string sectionName)
        {
            var clientId = Configuration[$"{sectionName}:ClientId"];
            var clientSecret = Configuration[$"{sectionName}:ClientSecret"];
            var redirectUri = Configuration[$"{sectionName}:RedirectUri"];

            if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret) && !string.IsNullOrEmpty(redirectUri))
            {
                if (sectionName == "OutlookApiSettings")
                {
                    services.AddTransient<OutlookApiClient>(provider => new OutlookApiClient(clientId, clientSecret, redirectUri));
                }
                else if (sectionName == "GmailApiSettings")
                {
                    //services.AddTransient<GmailApiClient>(provider => new GmailApiClient(clientId, clientSecret));
                }
                else if (sectionName == "YahooApiSettings")
                {
                    //services.AddTransient<YahooApiClient>(provider => new YahooApiClient(clientId, clientSecret));
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmailManager API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
