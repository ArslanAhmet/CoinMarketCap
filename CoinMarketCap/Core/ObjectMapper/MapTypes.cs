using CoinMarketCap.Core.Entities;
using CoinMarketCap.Core.Models;
using CoinMarketCap.Infrastructure.Data;
using CoinMarketCap.Infrastructure.Helpers;
using CoinMarketCap.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCap.Core.ObjectMapper
{
    public class MapTypes
    {
        public void Mappings(IServiceCollection services)
        {
            services.AddDbContext<CoinMarketCapContext>(opt => opt.UseInMemoryDatabase("CoinMarketCapDatabase"));
            
            services.AddScoped<IAssetRepository, AssetRepository>();
            
            services.AddTransient<ICoinMarketCapAccessService, CoinMarketCapAccessService>();

            string ApiUserName = "sample";
            string ApiPassword = "sample";
            string adress = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";
            services.AddSingleton<Infrastructure.Services.IHttpClientFactory>(new HttpClientFactory(
                adress,
                ApiUserName,
                ApiPassword));

            #region Assets
            services.AddTransient<IMapper<AssetForCreationDto, Asset>, AssetForCreationToAsset>();
            services.AddTransient<IAsyncMapper<Asset, AssetDto>, AssetToAssetDto>();
            services.AddTransient<IAsyncMapper<IEnumerable<Asset>, IEnumerable<AssetDto>>, AssetListToAssetDtoList>();
            
            #endregion

        }
    }
}
