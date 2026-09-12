using AIImpactAnalysis.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIImpactAnalysis.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IOrchestrationService _orchestrationService;

    public ChatController(
        IOrchestrationService orchestrationService)
    {
        _orchestrationService = orchestrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(
        [FromBody] string chat)
    {
        var result =
            await _orchestrationService
                .ProcessUserQueryAsync(chat);

        return Ok(result);
    }
}