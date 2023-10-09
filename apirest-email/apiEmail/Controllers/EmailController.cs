using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ApiEmail.Data;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet("messages")]
    public IActionResult GetUnreadMessages()
    {
        var messages = _emailService.GetUnreadMessages();
        return Ok(messages);
    }
}
