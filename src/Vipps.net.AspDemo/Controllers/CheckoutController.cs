using System.Threading.Tasks;
using System.Web.Http;
using Vipps.net.AspDemo.Services;

namespace Vipps.net.AspDemo.Controllers
{
    public class CheckoutController : ApiController
    {
        // POST api/checkout
        public async Task<string> Post()
        {
            return await CheckoutSessionService.CreateSession();
        }
    }
}
