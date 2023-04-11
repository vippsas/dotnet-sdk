---
sidebar_label: .NET
pagination_next: null
pagination_prev: null
---

# .NET SDK

The official .NET SDK for the Checkout and ePayment APIs.

Supports .NET Standard 2.0+, .NET Core 2.0+, and .NET Framework 4.8+.

**Features**

- Serialization/deserialization
- Authentication
- Network retries
- Idempotency

## Installation

.NET Core CLI:

```sh
dotnet add package vipps.net
```

## Usage

```C#
var vippsConfigurationOptions = new VippsConfigurationOptions
{
    ClientId = "CLIENT-ID",
    ClientSecret = "CLIENT-SECRET",
    MerchantSerialNumber = "MERCHANT-SERIAL-NUMBER",
    SubscriptionKey = "SUBSCRIPTION-KEY",
    UseTestMode = true
};

VippsConfiguration.ConfigureVipps(vippsConfigurationOptions);

var request = new InitiateSessionRequest
{
    MerchantInfo = new PaymentMerchantInfo
    {
        CallbackAuthorizationToken = Guid.NewGuid().ToString(),
        CallbackUrl = "https://your-url-here.com:3000",
        ReturnUrl = "https://your-url-here.com:3000",
    },
    Transaction = new PaymentTransaction
    {
        Amount = new Amount { Currency = "NOK", Value = 10000 },
        PaymentDescription = "test",
        Reference = Guid.NewGuid().ToString()
    }
};

var result = await CheckoutService.InitiateSession(request);

```

### Unimplemented parameters and properties

This SDK offers typed request and response classes. These classes might not be up-to-date if you are on the bleeding edge of our APIs, or if you use features that are not generally available.

#### Request

All request objects have a property called `AdditionalProperties`. This is a dictionary that if set will merge with the request object.

**`AdditionalProperties` example:**

```c#
InitiateSessionRequest initiateSessionRequest = new()
{
    Transaction = new PaymentTransaction()
    {
        Amount = new Amount()
        {
            Currency = "NOK",
            Value = 49000
        },
        PaymentDescription = "Hei"
    },
    AdditionalProperties =
    {
        { "Configuration", new { AcceptedPaymentMethods = new[] { "WALLET", "CARD" } } }
    }
};
```

#### Response

All response objects have a property called `RawResponse` that contains the response in the form of a Json Object.

**`RawResponse` example:**

```c#
var response = checkoutService.InitiateSession(initiateSessionRequest);
var cancellationUrl = response.RawResponse["cancellationUrl"].ToString();
```
