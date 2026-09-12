namespace AIImpactAnalysis.Tools;

public static class ConfluenceToolDefinition
{
    public const string Name = "search_confluence";

    public const string Description =
        "Search project information stored in Confluence. " +
        "Use this tool when the user asks about projects, " +
        "project cost, technologies, features, or business information.";

    public static readonly BinaryData Parameters =
        BinaryData.FromString("""
        {
          "type": "object",
          "properties": {
            "query": {
              "type": "string",
              "description": "The project, feature, technology, or business topic to search for."
            }
          },
          "required": ["query"],
          "additionalProperties": false
        }
        """);
}