using System;
using LABank.Entities.Contracts;
using LABank.Exceptions;

namespace LABank.Entities
{
    /// <summary>
    /// Represents customer of the bank
    /// </summary>
    public class Customer: ICustomer, ICloneable
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
        public long CustomerCode
        { 
            get => _customerCode;
            set
            {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be positive only");
                }
            }
        }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName
        { 
            get => _customerName;
            set
            {
                if (value.Length <= 40 && !string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("Customer Name should be not null and less than 40 characters long");
                }
            }
        }

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
        public string Mobile
        { 
            get => _mobile; 
            set
            {
                if (value.Length == 10)
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number must have 10 digits");
                }
            }
               
        }
        #endregion

        #region Methods
        public object Clone()
        {
            return new Customer()
            { 
                CustomerId = this.CustomerId,
                CustomerCode = this.CustomerCode,
                CustomerName = this.CustomerName,
                Address = this.Address,
                Landmark = this.Landmark,
                City = this.City,
                Country = this.Country,
                Mobile = this.Mobile
            };
        }
        #endregion
    }
}
