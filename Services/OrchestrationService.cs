using AIImpactAnalysis.Tools;

namespace AIImpactAnalysis.Services;

public class OrchestrationService : IOrchestrationService
{
    private readonly ConfluenceSearchTool _confluenceTool;

    public OrchestrationService(
        ConfluenceSearchTool confluenceTool)
    {
        _confluenceTool = confluenceTool;
    }

    public async Task<string> ProcessUserQueryAsync(string chat)
    {
        if (string.IsNullOrWhiteSpace(chat))
        {
            return "User query cannot be empty.";
        }

        // Call Confluence Function Tool
        var confluenceResult =
            await _confluenceTool.SearchConfluenceAsync(chat);

        return confluenceResult;
    }
}