using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RpaEmailAPI.Services;

namespace RpaEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet("mensagens")]
        public IActionResult GetMessages()
        {
            var messages = new List<Mensagem>
            {
                new Mensagem
                {
                    Assunto = "Exemplo de Assunto",
                    Remetente = "remetente@example.com",
                    Destinatario = "destinatario@example.com",
                    Data = DateTime.Now,
                    CorpoTexto = "Este é o corpo da mensagem."
                }
            };

            return Ok(messages);
        }
    }
}
