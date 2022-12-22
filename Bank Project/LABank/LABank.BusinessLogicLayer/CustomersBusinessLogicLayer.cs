using System;
using System.Collections.Generic;
using LABank.BusinessLogicLayer.ContractsBAL;
using LABank.DataAccessLayer.DALContracts;
using LABank.DataAccessLayer;
using LABank.Entities;
using LABank.Exceptions;
using LABank.Configuration;

namespace LABank.BusinessLogicLayer
{
    /// <summary>
    /// Represents customer business logic
    /// </summary>
    public class CustomersBusinessLogicLayer: ICustomersBusinessLogicLayer
    {
        #region Private Fields
        private ICustomersDataAccessLayer _customersDataAccessLayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes CustomersDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer()
        { 
            _customersDataAccessLayer= new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Private property that represents reference of CustomersDataAccessLayer
        /// </summary>
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set => _customersDataAccessLayer= value;
            get => _customersDataAccessLayer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of costumers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // invoke DAL
                return CustomersDataAccessLayer.GetCustomers();
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new customer to the existing customer list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns the id of the recently added customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // get all existings customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustomerCode = 0;
                foreach(Customer currCustomer in allCustomers)
                {
                    if (currCustomer.CustomerCode > maxCustomerCode)
                    {
                        maxCustomerCode = currCustomer.CustomerCode;
                    }
                }
                
                // generate new customer number
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustomerCode + 1;
                }
                else
                {
                    customer.CustomerCode = Settings.BaseCustomerNo + 1;
                }

                return CustomersDataAccessLayer.AddCustomer(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to updated</param>
        /// <returns>Returns a bool indication if user is updated successfully</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomersDataAccessLayer.UpdateCustomer(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">Customer ID to delete</param>
        /// <returns>Returns a bool indication if user is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                return CustomersDataAccessLayer.DeleteCustomer(customerId);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
