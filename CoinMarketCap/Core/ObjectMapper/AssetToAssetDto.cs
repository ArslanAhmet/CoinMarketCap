using CoinMarketCap.Core.Entities;
using CoinMarketCap.Core.Models;
using CoinMarketCap.Infrastructure.CoinMarketCapClasses;
using CoinMarketCap.Infrastructure.Helpers;
using CoinMarketCap.Infrastructure.Services;

namespace CoinMarketCap.Core.ObjectMapper
{
    public class AssetToAssetDto : IAsyncMapper<Asset, AssetDto>
    {
        ICoinMarketCapAccessService _coinMarketCapAccessService;
        public AssetToAssetDto(ICoinMarketCapAccessService coinMarketCapAccessService)
        {
            _coinMarketCapAccessService = coinMarketCapAccessService;
        }
        public async Task<AssetDto> MapAsync(Asset entity)
        {

            Datum datum = await _coinMarketCapAccessService.CoinInstantPriceAsync();
            //double instanPrice = 500;
            //double percent_change_24h = -3;
            return new AssetDto
            {
                Id = entity.Id,
                CoinID = entity.CoinID,
                InstantPrice = datum.quote.USD.price,
                //InstantPrice = instanPrice,
                Holdings = entity.Holdings,
                AverageBuyPrice = entity.AverageBuyPrice,
                H24Difference = datum.quote.USD.percent_change_24h,
                //H24Difference = percent_change_24h,
                ProfitLoss = (datum.quote.USD.price * entity.Holdings) - (entity.AverageBuyPrice * entity.Holdings) 
                //ProfitLoss = (instanPrice * entity.Holdings) - (entity.AverageBuyPrice * entity.Holdings)
            };
        }
    }
}
