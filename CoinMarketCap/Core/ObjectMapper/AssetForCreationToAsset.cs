using CoinMarketCap.Core.Entities;
using CoinMarketCap.Core.Models;
using CoinMarketCap.Infrastructure.Helpers;

namespace CoinMarketCap.Core.ObjectMapper
{
    public class AssetForCreationToAsset : IMapper<AssetForCreationDto, Asset>
    {
        public Asset Map(AssetForCreationDto input)
        {
            var entity = new Asset
            {
                CoinID = input.CoinID,
                Holdings = input.Quantity,
                AverageBuyPrice = input.PricePerCoin
            };

            return entity;
        }
    }
}
