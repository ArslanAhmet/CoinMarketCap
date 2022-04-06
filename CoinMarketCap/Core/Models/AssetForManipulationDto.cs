using System.ComponentModel.DataAnnotations;

namespace CoinMarketCap.Core.Models
{
    public abstract class AssetForManipulationDto
    {
        [Required(ErrorMessage = "CoinID is required")]
        public int CoinID { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "PricePerCoin is required")]
        public double PricePerCoin { get; set; }
    }
}
