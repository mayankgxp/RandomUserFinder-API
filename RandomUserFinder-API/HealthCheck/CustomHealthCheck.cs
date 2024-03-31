using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RandomUserFinder.HealthCheck;

public class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return IsServiceHealthy()
            ? Task.FromResult(HealthCheckResult.Healthy("Service is up and running."))
            : Task.FromResult(HealthCheckResult.Unhealthy("Service is not up and running."));
    }

    private static bool IsServiceHealthy()
    {
        //logic to check...
        return true;
    }
}
