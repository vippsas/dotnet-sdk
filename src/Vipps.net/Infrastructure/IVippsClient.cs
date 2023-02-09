using Vipps.Models;

namespace Vipps.net.Infrastructure
{
    public interface IVippsClient
    {
        Task<TResponse> ExecuteRequest<TRequest, TResponse>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            Dictionary<string, string>? headers,
            CancellationToken cancellationToken = default
        )
            where TRequest : VippsRequest;

        Task ExecuteRequest<TRequest>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            Dictionary<string, string>? headers,
            CancellationToken cancellationToken = default
        )
            where TRequest : VippsRequest;

        Task<TResponse> ExecuteRequest<TResponse>(
            string path,
            HttpMethod httpMethod,
            Dictionary<string, string>? headers,
            CancellationToken cancellationToken = default
        );
    }
}
