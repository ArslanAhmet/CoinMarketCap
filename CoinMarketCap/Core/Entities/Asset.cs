namespace CoinMarketCap.Core.Entities
{
    public class Asset : BaseEntity
    {
        public int CoinID { get; set; }
        public double Holdings { get; set; }
        public double AverageBuyPrice { get; set; }
    }
}
