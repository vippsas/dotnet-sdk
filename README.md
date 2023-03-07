# Vipps.net

The official Vipps .NET SDK for the Checkout and Epayment APIs.

Supports .NET Standard 2.0+, .NET Core 2.0+ and .NET Framework 4.8+

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

The Vipps SDK offer typed request and response classes. These classes might not be up to date if you are on the bleeding edge of our APIs, or if you use features that are not generally available.

#### Request

All request objects have a property called "ExtraParameters". This is a dynamic object that if set will merge with the request object.

##### ExtraParameters example

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
    ExtraParameters = new
    {
        Transaction = new
        {
            Metadata = new
            {
                KID = "100001"
            }
        }
    }
};
```

#### Response

All response objects have a property called RawResponse that contains the response in the form of a JsonObject.

##### RawResponse example

```c#
var response = checkoutService.InitiateSession(initiateSessionRequest);
var cancellationUrl = response.RawResponse["cancellationUrl"].ToString();
```


### Versioning

The patch version (major.minor.patch) is automatically bumped on every main push using https://github.com/dotnet/Nerdbank.GitVersioning.

**Increasing major and minor versions**

It is possible to set the major and minor version manually by:

1. Bump the version in the src/version.json files version field.

**The pipeline will on every push to main:**

1. Create a tag with the version for the commit.
2. Create a release with the tag and version. This will also generate release notes.
3. Pack a nuget package with the version specified.
4. Publish the nuget package.
