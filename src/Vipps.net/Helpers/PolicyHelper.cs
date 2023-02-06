using Microsoft.Extensions.Logging;
using Polly.Fallback;
using Polly.Retry;
using Polly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vipps.Helpers
{
    internal static class PolicyHelper
    {
        private const string CommonErrorMessagePart =
            ". Status was {statusCode}, response body was {body}";
        private const string CommonWarningMessage =
            "Retry #{retryCount} failed because response status was {responseStatus}. Exception was {exception}. Sleeping for {sleepDurationMs} ms.";
        private static readonly ImmutableArray<int> _defaultSleepDurationsMs =
            ImmutableArray.Create(100, 250, 1000);

        internal static AsyncFallbackPolicy<HttpResponseMessage> GetFallbackPolicy(
            ILogger logger,
            string errorMessage
        )
        {
            return Policy
                .HandleResult<HttpResponseMessage>(
                    r => ((int)r.StatusCode) >= (int)HttpStatusCode.InternalServerError
                )
                .FallbackAsync(
                    fallbackValue: new HttpResponseMessage(HttpStatusCode.InternalServerError),
                    onFallbackAsync: async (result, context) =>
                    {
                        logger.LogError(
                            $"{errorMessage}{CommonErrorMessagePart}",
                            result.Result.StatusCode,
                            await result.Result.Content.ReadAsStringAsync()
                        );
                    }
                );
        }

        internal static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(
            ILogger logger,
            int[]? sleepDurationsMs = null
        )
        {
            return Policy
                .HandleResult<HttpResponseMessage>(
                    r => ((int)r.StatusCode) >= (int)HttpStatusCode.InternalServerError
                )
                .WaitAndRetryAsync(
                    (sleepDurationsMs ?? _defaultSleepDurationsMs.ToArray())
                        .Select(s => TimeSpan.FromMilliseconds(s))
                        .ToArray(),
                    onRetry: (
                        DelegateResult<HttpResponseMessage> response,
                        TimeSpan sleepDuration,
                        int retryCount,
                        Context ctx
                    ) =>
                        logger.LogWarning(
                            CommonWarningMessage,
                            retryCount,
                            response?.Result.StatusCode,
                            response?.Exception,
                            Convert.ToInt32(sleepDuration.Milliseconds)
                        )
                );
        }

        internal static AsyncPolicy<HttpResponseMessage> GetRetryPolicyWithFallback(
            ILogger logger,
            string errorMessage,
            int[]? sleepDurationsMs = null
        )
        {
            return GetFallbackPolicy(logger, errorMessage)
                .WrapAsync(GetRetryPolicy(logger, sleepDurationsMs));
        }
    }
}
