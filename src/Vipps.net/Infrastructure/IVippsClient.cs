namespace Vipps.net.Infrastructure
{
    public interface IVippsClient
    {
        Task<TResponse> ExecuteRequest<TRequest, TResponse>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            Dictionary<string, string>? headers,
            CancellationToken? cancellationToken
        );
    }
}
