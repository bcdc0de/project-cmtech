using System;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

public class EmailController : ControllerBase
{
    private readonly Email _email;
    private readonly ENV _env;

    public EmailController(Email email, IOptions<ENV> envOptions)
    {
        _email = email;
        _env = envOptions.Value;
    }

}
