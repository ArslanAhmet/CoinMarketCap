﻿namespace CoinMarketCap.Infrastructure.Helpers
{
    public class AssetsResourceParameters
    {
        private const int maxPageSize = 30;
        private int _pageSize = 30;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? SearchQuery { get; set; }
        public string OrderBy { get; set; } = "Ad";
        public string? Fields { get; set; }
    }
}
