

using Entities;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents Stocks service that includes operations like buy order, sell order
    /// </summary>
    public interface IStocksRepository
    {
        /// <summary>
        /// Creates a buy order
        /// </summary>
        /// <param name="buyOrder">Buy order object</param>
        Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);
        Task<SellOrder> CreateSellOrder(SellOrder sellOrder);
    
        Task<List<BuyOrder>> GetAllBuyOrders();
        Task<List<SellOrder>> GetSellOrders();
    }
}
