using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that represents a buy order response
    /// </summary>
    public class BuyOrderResponse : IOrderResponse
    {
        /// <summary>
        /// The unique ID of the buy order
        /// </summary>
        public Guid BuyOrderID { get; set; }

        /// <summary>
        /// The unique symbol of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string StockSymbol { get; set; }

        /// <summary>
        /// The company name of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string StockName { get; set; }

        /// <summary>
        /// Date and time of order, when it is placed by the user
        /// </summary>
        public DateTime DateAndTimeOfOrder { get; set; }

        /// <summary>
        /// The number of stocks
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// The price of each stock
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Total trade amount
        /// </summary>
        public double TradeAmount { get; set; }

        public OrderType TypeOfOrder { get; set; }

        /// <summary>
        /// Checks if the current object and other (parameter) object values match
        /// </summary>
        /// <param name="obj">Other object of BuyOrderResponse class, to compare</param>
        /// <returns>True or false determines whether current object and other objects match</returns>
        public override bool Equals(object? obj)
        {
           if (obj == null)
           {
                return false;
           }
           if (obj is not BuyOrderResponse)
           {
                return false;
           }

            BuyOrderResponse objCasted = (BuyOrderResponse)obj;

            return BuyOrderID == objCasted.BuyOrderID
                && StockName == objCasted.StockName
                && StockSymbol == objCasted.StockSymbol
                && Price == objCasted.Price
                && Quantity == objCasted.Quantity
                && DateAndTimeOfOrder == objCasted.DateAndTimeOfOrder
                && TradeAmount == objCasted.TradeAmount;
        }
    }

    public static class BuyOrderExtensions
    { 
        /// <summary>
        /// An extension method to convert an object of BuyOrder class into BuyOrderResponse class
        /// </summary>
        /// <param name="buyOrder">The BuyOrder object to convert</param>
        /// <returns>Returns the converted BuyOrderResponse object</returns>
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse() { 
                BuyOrderID = buyOrder.BuyOrderID, 
                StockSymbol = buyOrder.StockSymbol, 
                StockName = buyOrder.StockName, 
                Price = buyOrder.Price, 
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity, 
                TradeAmount = buyOrder.Price * buyOrder.Quantity };
        }
    }

}
