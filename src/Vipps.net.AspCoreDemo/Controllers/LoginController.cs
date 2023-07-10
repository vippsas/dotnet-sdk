using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vipps.net.Models.Login;
using Vipps.net.Services;

namespace Vipps.net.AspCore31Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;

        public LoginController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetStartLoginURI()
        {
            StartLoginURIRequest startLoginUriRequest = new StartLoginURIRequest()
            {
                RedirectURI = "http://localhost:3000",
                Scope = "openid email name phoneNumber",
                AuthenticationMethod = AuthenticationMethod.Post
            };
            
            return LoginService.GetStartLoginUri(startLoginUriRequest);
        }
    }
}
