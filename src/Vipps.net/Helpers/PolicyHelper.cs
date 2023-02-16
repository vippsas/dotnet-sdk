using System;
using System.Diagnostics;
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

        private const string TraceCommonErrorMessagePart =
            ". Status was {0}, response body was {1}";

        private const string TraceCommonWarningMessage =
            "Retry #{0} failed because response status was {1}. Exception was {2}. Sleeping for {3} ms.";

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
                        var responseString = await result.Result.Content
                            .ReadAsStringAsync()
                            .ConfigureAwait(false);
                        logger?.LogError(
                            $"{errorMessage}{CommonErrorMessagePart}",
                            result.Result.StatusCode,
                            responseString
                        );
                        Trace.TraceError(
                            $"{errorMessage}{TraceCommonErrorMessagePart}",
                            result.Result.StatusCode,
                            responseString
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
                    {
                        logger?.LogWarning(
                            CommonWarningMessage,
                            retryCount,
                            response?.Result?.StatusCode,
                            response?.Exception,
                            Convert.ToInt32(sleepDuration.Milliseconds)
                        );

                        Trace.TraceWarning(
                            TraceCommonWarningMessage,
                            retryCount,
                            response?.Result?.StatusCode,
                            response?.Exception,
                            Convert.ToInt32(sleepDuration.Milliseconds)
                        );
                    }
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
