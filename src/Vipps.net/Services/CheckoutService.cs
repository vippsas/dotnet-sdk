﻿using Vipps.Models.Checkout.GetSession;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;

namespace Vipps.Services
{
    public static class CheckoutService
    {
        public static async Task<InitiateSessionResponse> InitiateSession(
            InitiateSessionRequest initiateSessionRequest,
            CancellationToken? cancellationToken
        )
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/checkout/v3/session";
            var sessionInitiationResult = await VippsConfiguration.VippsClient.ExecuteRequest<
                InitiateSessionRequest,
                InitiateSessionResponse
            >(
                requestPath,
                HttpMethod.Post,
                initiateSessionRequest,
                GetHeaders(),
                cancellationToken
            );
            if (sessionInitiationResult is null)
            {
                throw new Exception("Failed response from session initiation");
            }
            return sessionInitiationResult;
        }

        public static async Task<GetSessionInfoResponse> GetSessionInfo(
            string reference,
            CancellationToken? cancellationToken
        )
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/checkout/v3/session/{reference}";
            var getSessionResult =
                await VippsConfiguration.VippsClient.ExecuteRequest<GetSessionInfoResponse>(
                    requestPath,
                    HttpMethod.Get,
                    GetHeaders(),
                    cancellationToken
                );
            if (getSessionResult is null)
            {
                throw new Exception("Failed response from session polling");
            }
            return getSessionResult;
        }

        private static Dictionary<string, string> GetHeaders()
        {
            if (string.IsNullOrEmpty(VippsConfiguration.ClientId))
            {
                throw new InvalidOperationException(
                    $"Missing configuration: {nameof(VippsConfiguration.ClientId)}"
                );
            }
            if (string.IsNullOrEmpty(VippsConfiguration.ClientSecret))
            {
                throw new InvalidOperationException(
                    $"Missing configuration: {nameof(VippsConfiguration.ClientSecret)}"
                );
            }

            return new Dictionary<string, string>
            {
                { Constants.HeaderNameClientId, VippsConfiguration.ClientId },
                { Constants.HeaderNameClientSecret, VippsConfiguration.ClientSecret }
            };
        }
    }
}
