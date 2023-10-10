using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; // Adicione esta referência
using RpaEmailAPI.Services;
using RpaEmailAPI.Data;

namespace RpaEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Injete a IConfiguration

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("importar-emails")]
        public IActionResult ImportEmails()
        {
            try
            {
                var email = new Email(iMAP_HOST: "outlook.office365.com", iMAP_USER: "rs_teste@outlook.com", iMAP_PASSWORD: "rsteste123456");
                email.Connect().Wait(); 

                var messages = email.GetMessages();

                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var databaseManager = new DatabaseManager(connectionString);

                databaseManager.InsertMessages(messages);

                return Ok("E-mails inseridos no banco de dados com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
