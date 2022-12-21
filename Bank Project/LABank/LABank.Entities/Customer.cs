using System;

namespace LABank.Entities
{
    /// <summary>
    /// Represents customer of the bank
    /// </summary>
    public class Customer: ICustomer
    {
        #region Private fields
        private Guid _customerId;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Public properties
        /// <summary>
        /// Guid of customer for unique identification
        /// </summary>
        public Guid CustomerId { get => _customerId; set => _customerId = value; }
        /// <summary>
        /// Aut-generated code number of the customer
        /// </summary>
        public long CustomerCode { get => _customerCode; set => _customerCode = value; }
        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName { get => _customerName; set => _customerName = value; }
        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Address { get => _address; set => _address = value; }
        /// <summary>
        /// Landmark of the customer
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// City of the customer
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// Country of the customer
        /// </summary>
        public string Country { get => _country; set => _country = value; }
        /// <summary>
        /// Mobile of the customer
        /// </summary>
        public string Mobile { get => _mobile; set => _mobile = value; }
        #endregion
    }
}
