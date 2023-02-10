using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Vipps.Models;
using Vipps.Models.Checkout.GetSession;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;

namespace Vipps.Services;

public class CheckoutService
{
    private readonly VippsConfiguration _vippsConfiguration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<CheckoutService> _logger =
        VippsLogging.LoggerFactory.CreateLogger<CheckoutService>();

    public CheckoutService(VippsConfiguration vippsConfiguration, HttpClient httpClient)
    {
        _vippsConfiguration = vippsConfiguration;
        _httpClient = httpClient;

        _httpClient.DefaultRequestHeaders.Add("client_id", vippsConfiguration.ClientId);
        _httpClient.DefaultRequestHeaders.Add("client_secret", vippsConfiguration.ClientSecret);
        _httpClient.DefaultRequestHeaders.Add(
            "Ocp-Apim-Subscription-Key",
            vippsConfiguration.SubscriptionKey
        );
        _httpClient.DefaultRequestHeaders.Add(
            "Merchant-Serial-Number",
            vippsConfiguration.MerchantSerialNumber
        );
        _httpClient.DefaultRequestHeaders.Add("Vipps-System-Name", "checkout-sandbox");
        _httpClient.DefaultRequestHeaders.Add("Vipps-System-Version", "0.9");
        _httpClient.DefaultRequestHeaders.Add("Vipps-System-Plugin-Name", "checkout-sandbox");
        _httpClient.DefaultRequestHeaders.Add("Vipps-System-Plugin-Version", "0.9");
        _logger.LogInformation("Checkoutservice initiated");
    }

    public async Task<InitiateSessionResponse> InitiateSession(
        InitiateSessionRequest initiateSessionRequest
    )
    {
        var serializedRequest = VippsRequestSerializer.SerializeVippsRequest(
            initiateSessionRequest
        );
        var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage()
        {
            Content = content,
            RequestUri = new Uri(_vippsConfiguration.BaseUrl + "/checkout/v3/session"),
            Method = HttpMethod.Post
        };

        var sessionInitiationResponse = await _httpClient.SendAsync(request);
        if (!sessionInitiationResponse.IsSuccessStatusCode)
        {
            throw new Exception(
                "Failed session initiation: "
                    + await sessionInitiationResponse.Content.ReadAsStringAsync()
            );
        }

        var sessionInitiationResult =
            await sessionInitiationResponse.Content.ReadFromJsonAsync<InitiateSessionResponse>();
        if (sessionInitiationResult is null)
        {
            throw new Exception("Failed response from session initiation");
        }

        return sessionInitiationResult;
    }

    public async Task<GetSessionInfoResponse> GetSessionInfo(string reference)
    {
        var request = new HttpRequestMessage()
        {
            RequestUri = new Uri(_vippsConfiguration.BaseUrl + "/checkout/v3/session/" + reference),
            Method = HttpMethod.Get
        };
        var getSessionResponse = await _httpClient.SendAsync(request);
        if (!getSessionResponse.IsSuccessStatusCode)
        {
            throw new Exception(
                "Failed session initiation: " + await getSessionResponse.Content.ReadAsStringAsync()
            );
        }

        var getSessionResult =
            await getSessionResponse.Content.ReadFromJsonAsync<GetSessionInfoResponse>();
        if (getSessionResult is null)
        {
            throw new Exception("Failed response from session polling");
        }

        return getSessionResult;
    }
}
