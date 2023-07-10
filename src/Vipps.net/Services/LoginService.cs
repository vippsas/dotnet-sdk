using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Login;

namespace Vipps.net.Services
{

    public class LoginService
    {
        public static string GetStartLoginUri(StartLoginURIRequest startLoginUriRequest, CancellationToken cancellationToken = default)
        {
            string startLoginUri = $"{VippsConfiguration.BaseUrl}/access-management-1.0/access/oauth2/auth" +
                                   $"?client_id={VippsConfiguration.ClientId}" +
                                   $"&response_type=code" +
                                   $"&scope={startLoginUriRequest.Scope}" +
                                   $"&state={Guid.NewGuid().ToString()}" +
                                   $"&redirect_uri={startLoginUriRequest.RedirectURI}";
            
            if (startLoginUriRequest.AuthenticationMethod == AuthenticationMethod.Post)
            {
                startLoginUri = $"{startLoginUri}&response_mode=form_post";
            }

            return startLoginUri; 
        }
    }
}
