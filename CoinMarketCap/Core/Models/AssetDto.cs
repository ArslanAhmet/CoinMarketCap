namespace CoinMarketCap.Core.Models
{
    public class AssetDto
    {
        public int Id { get; set; }
        public int CoinID { get; set; }
        public double InstantPrice { get; set; }
        public double Holdings { get; set; }
        public double AverageBuyPrice { get; set; }
        public double H24Difference { get; set; }
        public double ProfitLoss { get; set; }
        
    }
}
