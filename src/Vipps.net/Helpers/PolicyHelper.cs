using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Fallback;
using Polly.Retry;

namespace Vipps.Helpers
{
    internal static class PolicyHelper
    {
        private const string CommonErrorMessagePart = ". Status was {0}, response body was {1}";

        private const string CommonWarningMessage =
            "Retry #{0} failed because response status was {1}. Exception was {2}. Sleeping for {3} ms.";

        internal static AsyncFallbackPolicy<HttpResponseMessage> GetFallbackPolicy(
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
                        Trace.TraceError(
                            $"{errorMessage}{CommonErrorMessagePart}",
                            result.Result.StatusCode,
                            await result.Result.Content.ReadAsStringAsync().ConfigureAwait(false)
                        );
                    }
                );
        }

        internal static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
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
                        Trace.TraceWarning(
                            CommonWarningMessage,
                            retryCount,
                            response?.Result?.StatusCode,
                            response?.Exception,
                            Convert.ToInt32(sleepDuration.Milliseconds)
                        )
                );
        }

        internal static AsyncPolicy<HttpResponseMessage> GetRetryPolicyWithFallback(
            string errorMessage
        )
        {
            return GetFallbackPolicy(errorMessage).WrapAsync(GetRetryPolicy());
        }
    }
}
