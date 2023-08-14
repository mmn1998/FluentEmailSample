using FluentEmail.API.DTOs;
using FluentEmail.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentEmail.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly ILogger<EmailController> _logger;

    public EmailController(IEmailService emailService,ILogger<EmailController> logger)
	{
        _emailService = emailService;
        _logger = logger;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> SendEmail([FromBody] EmailMetadata request)
    {
        await _emailService.Send(request);
        return Ok();
    }

}
