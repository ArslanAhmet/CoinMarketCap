using CoinMarketCap.Core.Entities;
using CoinMarketCap.Infrastructure.Helpers;

namespace CoinMarketCap.Infrastructure.Data
{
    public interface IAssetRepository
    {
        void AddAsset(Asset assetEntity);
        Task<List<Asset>> GetAssets(AssetsResourceParameters assetsResourceParameters);
        Task<Asset> GetAssetAsync(int Id);
        Task SaveChangesAsync();
    }
}
