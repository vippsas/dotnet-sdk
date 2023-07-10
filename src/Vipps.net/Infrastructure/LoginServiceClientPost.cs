using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Vipps.net.Infrastructure
{
    internal sealed class LoginServiceClientPost : BaseServiceClient
    {
        internal LoginServiceClientPost(IVippsHttpClient vippsHttpClient)
            : base(vippsHttpClient) { }

        protected override async Task<Dictionary<string, string>> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            return await Task.FromResult(new Dictionary<string, string> { });
        }
    }
}
