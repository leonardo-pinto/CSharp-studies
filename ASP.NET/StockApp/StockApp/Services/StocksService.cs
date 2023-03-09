using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Services
{
    public class StocksService : IStocksService
    {
        //private readonly StockMarketDbContext _db;
        //private readonly List<BuyOrder> _buyOrders;
        //private readonly List<SellOrder> _sellOrders;
        // change name to applicationdb
        private readonly IStocksRepository _stocksRepository;

        public StocksService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(buyOrderRequest));
            }

            // Model validation
            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            await _stocksRepository.CreateBuyOrder(buyOrder);

            //_db.BuyOrders.Add(buyOrder);
            //await _db.SaveChangesAsync();
            
            //_buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();
        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(sellOrderRequest));
            }

            // Model validation
            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();
            sellOrder.SellOrderID = Guid.NewGuid();

            await _stocksRepository.CreateSellOrder(sellOrder);
            //_db.SellOrders.Add(sellOrder);
            //await _db.SaveChangesAsync();

            return sellOrder.ToSellOrderResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            List<BuyOrder> buyOrders = await _stocksRepository.GetAllBuyOrders();

            return buyOrders.Select(buyOrder => buyOrder.ToBuyOrderResponse()).ToList();

            //List<BuyOrderResponse> buyOrderResponse = new();
            //foreach (BuyOrder buyOrder in _buyOrders)
            //{
            //    buyOrderResponse.Add(buyOrder.ToBuyOrderResponse());
            //}

            //return buyOrderResponse;
        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            List<SellOrder> sellOrders = await _stocksRepository.GetSellOrders();

            return sellOrders.Select(sellOrder => sellOrder.ToSellOrderResponse()).ToList();

            //List<SellOrderResponse> sellOrderResponse = new();
            //foreach (SellOrder sellOrder in _sellOrders)
            //{
            //    sellOrderResponse.Add(sellOrder.ToSellOrderResponse());
            //}

            //return sellOrderResponse;
        }
    }
}
