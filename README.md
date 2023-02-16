# Vipps.net

The official Vipps .NET SDK.

## Features

- Serialization/deserialization
- Authentication
- Retries
- Idempotency
- Support for API not-yet implemented in SDK
- Caching of Access Token
- Other ideas?

## Installation

Todo

## Documentation

### Unimplemented parameters and properties

The Vipps SDK offer typed request and response classes. These classes may not be updated if you are on the bleeding edge of our API's, or if you use features that are not generally available.

#### Request

All request objects also have a property called "ExtraParameters". This is a dynamic object that if set will merge with the request object.

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

All response objects have a property called RawResponse that contains the RawResponse in the form of a JsonObject.

##### RawResponse example

```c#
var response = checkoutService.InitiateSession(initiateSessionRequest);
response.RawResponse
    .First(property => property.Key == "cancellationUrl")
    .Value?.GetValue<string>()
```

## Usage

Todo
