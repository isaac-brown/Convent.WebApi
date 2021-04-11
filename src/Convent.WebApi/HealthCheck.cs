// <copyright file="HealthCheck.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Convent.WebApi
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    /// <summary>
    /// Health check endpoint.
    /// </summary>
    public class HealthCheck : IHealthCheck
    {
        /// <inheritdoc/>
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var healthyResult = HealthCheckResult.Healthy("Everything is good");

            return Task.FromResult(healthyResult);
        }
    }
}
