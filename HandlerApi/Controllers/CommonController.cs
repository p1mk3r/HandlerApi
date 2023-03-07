using HandlerApi.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Patterns.Diagnostics;

namespace HandlerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommonController : ControllerBase
{
    private readonly ILogger<CommonController> _logger;
    private readonly IMediator _mediator;

    public CommonController(
        IMediator mediator,
        ILogger<CommonController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));;
    }
    
    [HttpPost(Name = "Message")]
    [Log]
    public async Task<ActionResult> TreatMessage(Message message)
    {
        // _logger.LogInformation(Json);
        var request = MessageParser.CreateRequestByMessageName(message);
        var result = await _mediator.Send(request);
        
        return Ok(result);
    }
}