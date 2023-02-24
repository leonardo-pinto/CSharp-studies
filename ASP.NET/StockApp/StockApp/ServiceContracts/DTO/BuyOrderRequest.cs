using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that represents a buy order to purchase the stocks
    /// </summary>
    public class BuyOrderRequest : IValidatableObject
    {
        /// <summary>
        /// The unique symbol of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string StockSymbol { get; set; }
        
        
        /// <summary>
        /// The company of the stock
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string? StockName { get; set; }
        
        /// <summary>
        /// Date and time or order, when it is placed by the user
        /// </summary>
        public DateTime DateAndTimeOfOrder { get; set; }
        
        /// <summary>
        /// The number of stocks to buy
        /// </summary>
        [Range(1, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public uint Quantity { get; set; }
        
        /// <summary>
        /// The price of each stock
        /// </summary>
        [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public double Price { get; set; }

        /// <summary>
        /// Model class-level validation using IValidatableObject
        /// </summary>
        /// <param name="validationContext">Validation Context to validate</param>
        /// <returns>Returns validation errors as ValidationResult</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new();

            if (DateAndTimeOfOrder < Convert.ToDateTime("2000-01-01"))
            {
                results.Add(new ValidationResult("Date of the order should not be older than Jan 01, 2000."));
            }
            return results;
        }

        /// <summary>
        /// Converts the current object of BuyOrderRequest into a new object of BuyOrder type
        /// </summary>
        /// <returns>A new object of BuyOrder class</returns>
        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}