using OpenAI;
using OpenAI.Chat;

namespace AIImpactAnalysis.Services;

public class CohereService : ICohereService
{
    private readonly ChatClient _chatClient;

    public CohereService(IConfiguration configuration)
    {
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
                configuration["Cohere:BaseUrl"]
                ?? "https://api.cohere.com/compatibility/v1")
        };

        var client = new OpenAIClient(
            new System.ClientModel.ApiKeyCredential(apiKey),
            options);

        _chatClient = client.GetChatClient(
            configuration["Cohere:Model"]
            ?? "command-a-plus-05-2026");
    }

    public async Task<string> ProcessQueryAsync(
        string userQuery)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(
                """
                You are an AI project impact analysis assistant.

                Answer using the information provided by the
                application's tools.

                Do not invent project costs or project details.
                If information is unavailable, clearly say so.
                """),

            new UserChatMessage(userQuery)
        };

        var response =
            await _chatClient.CompleteChatAsync(messages);

        return response.Value.Content[0].Text;
    }
}