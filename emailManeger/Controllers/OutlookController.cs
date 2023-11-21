using System;
using Microsoft.AspNetCore.Mvc;
using emailManeger.Services;

namespace emailManeger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutlookController : ControllerBase
    {
        private readonly IEmailService _outlookService;

        public OutlookController(IEmailService outlookService)
        {
            _outlookService = outlookService;
        }

        [HttpGet("emails")]
        public async Task<IActionResult> GetOutlookEmails()
        {
            try
            {
                var emails = await _outlookService.GetEmails();
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
  