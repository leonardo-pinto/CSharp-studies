using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents Stock service that includes operation like buy and sell orders
    /// </summary>
    public interface IStocksService
    {
        /// <summary>
        /// Creates a buy order
        /// </summary>
        /// <param name="buyOrderRequest">Buy order object</param>
        /// <returns>Buy order object</returns>
        Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        /// <summary>
        /// Creates a sell order
        /// </summary>
        /// <param name="sellOrderRequest">Sell order object</param>
        /// <returns>Sell order object</returns>
        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);

        /// <summary>
        /// Returns all existing buy orders
        /// </summary>
        /// <returns>Returns a list of all buy orders</returns>
        Task<List<BuyOrderResponse>> GetBuyOrders();

        /// <summary>
        /// Returns all existing sell orders
        /// </summary>
        /// <returns>Returns a list of all sell orders</returns>
        Task<List<SellOrderResponse>> GetSellOrders();
    }
}
