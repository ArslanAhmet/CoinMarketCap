using CoinMarketCap.Infrastructure.CoinMarketCapClasses;
using Newtonsoft.Json;
using System.Web;

namespace CoinMarketCap.Infrastructure.Services
{
    public class CoinMarketCapAccessService : ICoinMarketCapAccessService
    {
        IHttpClientFactory _httpClientFactory;
        IConfiguration _configuration;
        private ILogger<CoinMarketCapAccessService> _logger;
        public CoinMarketCapAccessService(ILogger<CoinMarketCapAccessService> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }


        public async Task<Datum> CoinInstantPriceAsync()
        {
            var client = _httpClientFactory.CreateClient();

            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

            HttpResponseMessage result = await client.GetAsync(url);
            
            string resultContent = await result.Content.ReadAsStringAsync();
            Root rootDeserialized = JsonConvert.DeserializeObject<Root>(resultContent);
            var quote = rootDeserialized.data.Where(q => q.id == 1839).FirstOrDefault();
            return quote;
        }
    }

}
