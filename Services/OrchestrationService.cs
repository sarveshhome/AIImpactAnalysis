using AIImpactAnalysis.Tools;

namespace AIImpactAnalysis.Services;

public class OrchestrationService : IOrchestrationService
{
    private readonly ConfluenceSearchTool _confluenceTool;
    private readonly ICohereService _cohereService;

    public OrchestrationService(
        ConfluenceSearchTool confluenceTool,
        ICohereService cohereService)
    {
        _confluenceTool = confluenceTool;
        _cohereService = cohereService;
    }

    public async Task<string> ProcessUserQueryAsync(
        string chat)
    {
        if (string.IsNullOrWhiteSpace(chat))
        {
            return "User query cannot be empty.";
        }

        // Call Cohere
        var response =
            await _cohereService.ProcessQueryAsync(chat);

        return response;
    }
}