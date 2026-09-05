using System.Text.Json;
using AIImpactAnalysis.Models;

namespace AIImpactAnalysis.Services;

public class ConfluenceSearchService
{
    private readonly string _filePath;

    public ConfluenceSearchService(IWebHostEnvironment environment)
    {
        _filePath = Path.Combine(
            environment.ContentRootPath,
            "Data",
            "Confluence.json");
    }

    public async Task<List<ConfluenceDocument>> SearchAsync(string query)
    {
        // 1. Load Confluence.json
        var json = await File.ReadAllTextAsync(_filePath);

        // 2. Convert JSON into C# objects
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var documents =
            JsonSerializer.Deserialize<List<ConfluenceDocument>>(json, options)
            ?? new List<ConfluenceDocument>();

        // 3. Search title and content
        var results = documents
            .Where(document =>
                document.Title.Contains(
                    query,
                    StringComparison.OrdinalIgnoreCase)
                ||
                document.Content.Contains(
                    query,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        // 4. Return matching documents
        return results;
    }
}