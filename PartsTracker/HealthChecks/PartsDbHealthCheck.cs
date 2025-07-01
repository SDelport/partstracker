using Microsoft.Extensions.Diagnostics.HealthChecks;
using PartsTracker.Services;

public class PartsDbHealthCheck(PartsService partService) : IHealthCheck
{
    public PartsService PartService { get; } = partService;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var anyParts = (await partService.GetAllAsync()).Any();
            return HealthCheckResult.Healthy("Database is reachable and has data.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Failed to reach database through PartService.", ex);
        }
    }
}