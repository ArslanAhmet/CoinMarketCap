using CoinMarketCap.Infrastructure.CoinMarketCapClasses;

namespace CoinMarketCap.Infrastructure.Services
{
    public interface ICoinMarketCapAccessService
    {
        Task<Datum> CoinInstantPriceAsync();
    }
}
