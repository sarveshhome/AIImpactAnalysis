using AIImpactAnalysis.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIImpactAnalysis.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfluenceController : ControllerBase
{
    private readonly ConfluenceSearchService _searchService;

    public ConfluenceController(
        ConfluenceSearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query is required.");
        }

        var results =
            await _searchService.SearchAsync(query);

        return Ok(results);
    }
}