using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Model class which represents a buy order
    /// </summary>
    public class BuyOrder
    {
        /// <summary>
        /// The unique ID of the buy order
        /// </summary>
        public Guid BuyOrderID { get; set; }

        /// <summary>
        /// The unique symbol of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string StockSymbol { get; set; }

        /// <summary>
        /// The company name of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string? StockName { get; set; }

        /// <summary>
        /// Date and time or order, when it is placed by the user
        /// </summary>
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(0, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        
        ///The number of stocks to buy
        public uint Quantity { get; set; }
        
        /// <summary>
        /// The price of each stock
        /// </summary>
        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public double Price { get; set; }
    }
}