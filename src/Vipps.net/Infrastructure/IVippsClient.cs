using System.Net.Http.Headers;

namespace Vipps.net.Infrastructure
{
    public interface IVippsClient
    {
        Task<TResponse> ExecuteRequest<TRequest, TResponse>(string path, HttpMethod httpMethod, TRequest? data, AuthenticationHeaderValue? authorizationheader, CancellationToken? cancellationToken);
    }
}
