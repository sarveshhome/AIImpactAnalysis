using AIImpactAnalysis.Services;

namespace AIImpactAnalysis.Tools;

public class ConfluenceSearchTool
{
    private readonly ConfluenceSearchService _searchService;

    public ConfluenceSearchTool(
        ConfluenceSearchService searchService)
    {
        _searchService = searchService;
    }

    public async Task<string> SearchConfluenceAsync(
        string query)
    {
        var documents =
            await _searchService.SearchAsync(query);

        if (documents.Count == 0)
        {
            return "No matching Confluence documents were found.";
        }

        return System.Text.Json.JsonSerializer.Serialize(
            documents,
            new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
    }
}