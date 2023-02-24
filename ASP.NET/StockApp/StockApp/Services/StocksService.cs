using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;

namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly List<BuyOrder> _buyOrders;
        private readonly List<SellOrder> _sellOrders;

        public StocksService()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();

        }

        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(buyOrderRequest));
            }

            // Model validation
            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();
        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(sellOrderRequest));
            }

            // Model validation
            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();
            sellOrder.SellOrderID = Guid.NewGuid();

            _sellOrders.Add(sellOrder);

            return sellOrder.ToSellOrderResponse();
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            List<BuyOrderResponse> buyOrderResponse = new();
            foreach (BuyOrder buyOrder in _buyOrders)
            {
                buyOrderResponse.Add(buyOrder.ToBuyOrderResponse());
            }

            return buyOrderResponse;
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            List<SellOrderResponse> sellOrderResponse = new();
            foreach (SellOrder sellOrder in _sellOrders)
            {
                sellOrderResponse.Add(sellOrder.ToSellOrderResponse());
            }

            return sellOrderResponse;
        }
    }
}
