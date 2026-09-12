namespace AIImpactAnalysis.Services;

public interface IOrchestrationService
{
    Task<string> ProcessUserQueryAsync(string chat);
}