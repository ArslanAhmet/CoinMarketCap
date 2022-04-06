using CoinMarketCap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCap.Infrastructure.Data
{
    public class CoinMarketCapContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CoinMarketCapDatabase");
        }

        public CoinMarketCapContext(DbContextOptions<CoinMarketCapContext> options)
            : base(options)
        {
        }
    }
}
