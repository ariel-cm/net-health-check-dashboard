using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWebApi.HealthChecks
{
    public class ChangeByMinuteHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int number = DateTime.UtcNow.Minute % 3;
            switch (number)
            {
                case 0:
                    return await Task.FromResult(HealthCheckResult.Healthy());
                case 1:
                    return await Task.FromResult(HealthCheckResult.Degraded());
                default:
                    return await Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}
