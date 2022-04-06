namespace CoinMarketCap.Infrastructure.Services
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
