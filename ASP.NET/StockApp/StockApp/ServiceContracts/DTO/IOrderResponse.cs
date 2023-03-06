namespace ServiceContracts.DTO
{
    public interface IOrderResponse
    {
        string? StockSymbol { get; set; }
        string? StockName { get; set; }
        DateTime DateAndTimeOfOrder { get; set; }
        uint Quantity { get; set; }
        double Price { get; set; }
        double TradeAmount { get; set; }
        OrderType TypeOfOrder { get; set; }

    }
    public enum OrderType
    {
        BuyOrder, SellOrder
    }
}
