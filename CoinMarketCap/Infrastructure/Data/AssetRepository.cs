using CoinMarketCap.Core.Entities;
using CoinMarketCap.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCap.Infrastructure.Data
{
    public class AssetRepository : IAssetRepository
    {
        private CoinMarketCapContext _context;
        public AssetRepository(CoinMarketCapContext context)
        {
            _context = context;
        }
        
        public void AddAsset(Asset newEntity)
        {
            var asset = _context.Assets.Where(a => a.CoinID == newEntity.CoinID).FirstOrDefault();
            if (asset != null)
            {
                double oldTotal = asset.AverageBuyPrice * asset.Holdings;
                double newTotal = newEntity.AverageBuyPrice * newEntity.Holdings;
                double averageBuyPrice = (oldTotal + newTotal) / (asset.Holdings + newEntity.Holdings);
                asset.Holdings += newEntity.Holdings;
                asset.AverageBuyPrice = averageBuyPrice;
            }
            else 
            {
                _context.Assets.Add(newEntity);
            }
            
        }

        public async Task<Asset> GetAssetAsync(int Id)
        {
            return await _context.Assets.Where(a => a.Id == Id).FirstOrDefaultAsync();         
        }

        public async Task<List<Asset>> GetAssets(AssetsResourceParameters assetsResourceParameters)
        {
            return await _context.Assets
                .OrderBy(x => x.Id).
                 Skip((assetsResourceParameters.PageNumber - 1) * assetsResourceParameters.PageSize)
                .Take(assetsResourceParameters.PageSize).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
