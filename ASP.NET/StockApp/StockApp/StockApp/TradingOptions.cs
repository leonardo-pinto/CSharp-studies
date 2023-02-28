namespace StockApp
{
    /// <summary>
    /// Represents Options Pattern for configuration
    /// </summary>
    public class TradingOptions
    {
        public string? DefaultStockSymbol { get; set; }
        public uint DefaultQuantity { get; set; }
    }
}
