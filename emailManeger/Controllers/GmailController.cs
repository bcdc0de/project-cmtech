using System;
using Microsoft.AspNetCore.Mvc;

namespace emailManeger.Controllers
{

    [ApiController]
    [Route("api/gmail")]
    public class GmailController : ControllerBase
    {
        /**private readonly IGmailService _gmailService;

        public GmailController(IGmailService gmailService)
        {
            _gmailService = gmailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmails()
        {
            var emails = await _gmailService.GetEmails();
            return Ok(emails);
        }*/
    }

}