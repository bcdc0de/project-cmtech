using System;
using Microsoft.AspNetCore.Mvc;

namespace EmailManeger.Controllers;

[ApiController]
[Route("api/yahoo")]
public class YahooController : ControllerBase
{
    /**private readonly IYahooService _yahooService;

    public YahooController(IYahooService yahooService)
    {
        _yahooService = yahooService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmails()
    {
        var emails = await _yahooService.GetEmails();
        return Ok(emails);
    }*/
}