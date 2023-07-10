using Vipps.net.Models.Login;

namespace Vipps.net.IntegrationTests;

[TestClass]
public class LoginServiceTests
{
    private const string CustomerPhoneNumber = "47753942";

    [TestMethod]
    public async Task Init_Ciba_With_Redirect_Test()
    {
        IVippsApi vippsApi = TestSetup.CreateVippsAPI();
        InitCibaRequest initCibaRequest = new InitCibaRequest()
        {
            Scope = "openid email",
            PhoneNumber = CustomerPhoneNumber,
            BindingMessage = "testing"
        };
        InitCibaResponse response = await vippsApi
            .LoginService()
            .InitCiba(initCibaRequest, AuthenticationMethod.Basic);
        Assert.IsNotNull(response.AuthReqId);
        Assert.IsNotNull(response.Interval);
        Assert.IsNotNull(response.ExpiresIn);
    }

    [TestMethod]
    public void Get_Start_Login_Uri()
    {
        IVippsApi vippsApi = TestSetup.CreateVippsAPI();
        StartLoginURIRequest startLoginUriRequest = new StartLoginURIRequest()
        {
            Scope = "openid email",
            RedirectURI = "http://localhost:3000"
        };

        var redirectUri = vippsApi
            .LoginService()
            .GetStartLoginUri(startLoginUriRequest, AuthenticationMethod.Post);
        Assert.IsNotNull(redirectUri);
        Assert.IsTrue(redirectUri.Contains("redirect_uri=http://localhost:3000"));
        Assert.IsTrue(redirectUri.Contains("response_mode=form_post"));
    }
}
