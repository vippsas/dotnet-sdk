namespace Vipps.net.Infrastructure
{
    public interface IVippsHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}
