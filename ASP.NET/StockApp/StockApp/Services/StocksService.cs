using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly StockMarketDbContext _db;
        //private readonly List<BuyOrder> _buyOrders;
        //private readonly List<SellOrder> _sellOrders;

        public StocksService(StockMarketDbContext stockMarketDbContext)
        {
            _db = stockMarketDbContext;

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

            _db.BuyOrders.Add(buyOrder);
            await _db.SaveChangesAsync();
            
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

            _db.SellOrders.Add(sellOrder);
            await _db.SaveChangesAsync();

            return sellOrder.ToSellOrderResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            List<BuyOrder> buyOrders = await _db.BuyOrders
                .OrderByDescending(buyOrder => buyOrder.DateAndTimeOfOrder)
                .ToListAsync();

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
            List<SellOrder> sellOrders = await _db.SellOrders
                .OrderByDescending(sellOrder => sellOrder.DateAndTimeOfOrder)
                .ToListAsync();

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
