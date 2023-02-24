using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that represents a sell order response
    /// </summary>
    public class SellOrderResponse
    {
        /// <summary>
        /// The unique ID of the sell order
        /// </summary>
        public Guid SellOrderID { get; set; }

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

        /// <summary>
        /// Checks if the current object and other (parameter) object values match
        /// </summary>
        /// <param name="obj">Other object of SellOrderResponse class, to compare</param>
        /// <returns>True or false determines whether current object and other objects match</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not SellOrderResponse)
            {
                return false;
            }

            SellOrderResponse objCasted = (SellOrderResponse)obj;

            return SellOrderID == objCasted.SellOrderID
                && StockName == objCasted.StockName
                && StockSymbol == objCasted.StockSymbol
                && Price == objCasted.Price
                && Quantity == objCasted.Quantity
                && DateAndTimeOfOrder == objCasted.DateAndTimeOfOrder
                && TradeAmount == objCasted.TradeAmount;
        }
    }

    public static class SellOrderExtensions
    {
        /// <summary>
        /// An extension method to convert an object of SellOrder class into SellOrderResponse class
        /// </summary>
        /// <param name="buyOrder">The SellOrder object to convert</param>
        /// <returns>Returns the converted SellOrderResponse object</returns>
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                SellOrderID = sellOrder.SellOrderID,
                StockSymbol = sellOrder.StockSymbol,
                StockName = sellOrder.StockName,
                Price = sellOrder.Price,
                DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
                Quantity = sellOrder.Quantity,
                TradeAmount = sellOrder.Price * sellOrder.Quantity
            };
        }
    }
}
