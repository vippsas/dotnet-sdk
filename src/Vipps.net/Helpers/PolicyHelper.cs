using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Fallback;
using Polly.Retry;

namespace Vipps.Helpers
{
    internal static class PolicyHelper
    {
        private const string CommonErrorMessagePart =
            ". Status was {statusCode}, response body was {body}";

        private const string CommonWarningMessage =
            "Retry #{retryCount} failed because response status was {responseStatus}. Exception was {exception}. Sleeping for {sleepDurationMs} ms.";

        internal static AsyncFallbackPolicy<HttpResponseMessage> GetFallbackPolicy(
            ILogger logger,
            string errorMessage
        )
        {
            return Policy
                .HandleResult<HttpResponseMessage>(
                    r => (int)r.StatusCode >= (int)HttpStatusCode.InternalServerError
                )
                .FallbackAsync(
                    new HttpResponseMessage(HttpStatusCode.InternalServerError),
                    async (result, context) =>
                    {
                        logger.LogError(
                            $"{errorMessage}{CommonErrorMessagePart}",
                            result.Result.StatusCode,
                            await result.Result.Content.ReadAsStringAsync().ConfigureAwait(false)
                        );
                    }
                );
        }

        internal static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(ILogger logger)
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(
                medianFirstRetryDelay: TimeSpan.FromMilliseconds(300),
                retryCount: 3
            );

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    delay,
                    (
                        DelegateResult<HttpResponseMessage> response,
                        TimeSpan sleepDuration,
                        int retryCount,
                        Context ctx
                    ) =>
                        logger.LogWarning(
                            CommonWarningMessage,
                            retryCount,
                            response?.Result?.StatusCode,
                            response?.Exception,
                            Convert.ToInt32(sleepDuration.Milliseconds)
                        )
                );
        }

        internal static AsyncPolicy<HttpResponseMessage> GetRetryPolicyWithFallback(
            ILogger logger,
            string errorMessage
        )
        {
            return GetFallbackPolicy(logger, errorMessage).WrapAsync(GetRetryPolicy(logger));
        }
    }
}
