using AIImpactAnalysis.Tools;
using OpenAI;
using OpenAI.Chat;

namespace AIImpactAnalysis.Services;

public class CohereService : ICohereService
{
    private readonly ChatClient _chatClient;
    private readonly ConfluenceSearchTool _confluenceTool;

    public CohereService(
        IConfiguration configuration,
        ConfluenceSearchTool confluenceTool)
    {
        _confluenceTool = confluenceTool;

        var apiKey =
            configuration["Cohere:ApiKey"]
            ?? Environment.GetEnvironmentVariable("COHERE_API_KEY");

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "Cohere API key is not configured.");
        }

        var options = new OpenAIClientOptions
        {
            Endpoint = new Uri(
                "https://api.cohere.ai/compatibility/v1")
        };

        var client = new OpenAIClient(
            new System.ClientModel.ApiKeyCredential(apiKey),
            options);

        _chatClient = client.GetChatClient(
            configuration["Cohere:Model"]
            ?? "command-a-plus-05-2026");
    }

    public async Task<string> ProcessQueryAsync(string userQuery)
{
    var messages = new List<ChatMessage>
    {
        new SystemChatMessage(
            """
            You are an AI project impact analysis assistant.

            Use the available tools when project information
            is required.

            Never invent project information.

            If the required information cannot be found,
            clearly tell the user.
            """),

        new UserChatMessage(userQuery)
    };

    var tools = new[]
    {
        CreateConfluenceTool()
    };

    while (true)
    {
        ChatCompletion response =
            await _chatClient.CompleteChatAsync(
                messages,
                new ChatCompletionOptions
                {
                    Tools = { tools[0] }
                });

        // Add Cohere's response to conversation
        messages.Add(new AssistantChatMessage(response));

        // No tool call → final answer
        if (response.FinishReason != ChatFinishReason.ToolCalls)
        {
            return response.Content[0].Text;
        }

        // Process tool calls
        foreach (var toolCall in response.ToolCalls)
        {
            if (toolCall.FunctionName ==
                ConfluenceToolDefinition.Name)
            {
                var arguments =
                    System.Text.Json.JsonSerializer
                        .Deserialize<Models.ConfluenceSearchArguments>(
                            toolCall.FunctionArguments.ToString());

                if (arguments == null ||
                    string.IsNullOrWhiteSpace(arguments.Query))
                {
                    messages.Add(
                        new ToolChatMessage(
                            toolCall.Id,
                            "Invalid search query."));

                    continue;
                }

                // Execute our actual C# tool
                var result =
                    await _confluenceTool
                        .SearchConfluenceAsync(
                            arguments.Query);

                // Give tool result back to LLM
                messages.Add(
                    new ToolChatMessage(
                        toolCall.Id,
                        result));
            }
        }
    }
}
     private ChatTool CreateConfluenceTool()
    {
            return ChatTool.CreateFunctionTool(
                functionName: ConfluenceToolDefinition.Name,
                functionDescription: ConfluenceToolDefinition.Description,
                functionParameters: ConfluenceToolDefinition.Parameters);
    }

}