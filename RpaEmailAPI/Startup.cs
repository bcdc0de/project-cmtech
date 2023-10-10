using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RpaEmailAPI.Data;
using RpaEmailAPI.Services;

namespace RpaEmailAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RpaEmailAPI", Version = "v1" });
            });

            services.AddSingleton<Email>((provider) =>
            {
                var emailSettings = Configuration.GetSection("EmailSettings");
                return new Email(
                    iMAP_HOST: emailSettings["IMAP_HOST"],
                    iMAP_USER: emailSettings["IMAP_USER"],
                    iMAP_PASSWORD: Configuration["SensitiveData:PASSWORD"]
                );
            });

            services.AddScoped<DatabaseManager>((provider) =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new DatabaseManager(connectionString);
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RpaEmailAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
