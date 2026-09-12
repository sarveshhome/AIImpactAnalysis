namespace AIImpactAnalysis.Services;

public interface ICohereService
{
    Task<string> ProcessQueryAsync(string userQuery);
}