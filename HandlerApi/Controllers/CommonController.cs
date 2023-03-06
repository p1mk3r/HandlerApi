using HandlerApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HandlerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommonController : ControllerBase
{
    private readonly ILogger<CommonController> _logger;

    public CommonController(ILogger<CommonController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    [HttpPost(Name = "Message")]
    public void TreatMessage(Message message)
    {
        
    }
}