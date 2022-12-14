using System;
using System.Collections.Generic;
using LABank.Entities;
using LABank.Exceptions;
using LABank.DataAccessLayer.DALContracts;

namespace LABank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Fields

        // private fields are used to initializes only
        // one time _customers field
        private static List<Customer> _customers;
        #endregion

        #region Constructors
        static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represents source customers collection
        /// </summary>
        private static List<Customer> Customers
        {
            get => _customers;
            set => _customers = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // create a new customers list
                // if any changes are made to Customers in the presentation
                // later, it would affect the current Customers list
                // to avoid this, we use the Clone method
                List<Customer> customersList = new List<Customer>();
                Customers.ForEach(customer => customersList.Add(customer.Clone() as Customer));
                return customersList;
            }
            // separate catch blocks for each context
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                // if we assign a new exception, we lose track
                // of where the exception was originally thrown
                // e.g. catch (Exception exception) { throw exception }
                throw;
            }
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate <Customer> predicate)
        {
            try
            {
                // create a new customers list
                List<Customer> customersList = new List<Customer>();

                // filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);
            
                // copy all customers from the source collection into the new customers list
                filteredCustomers.ForEach(customer => customersList.Add(customer.Clone() as Customer));
                return customersList;
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
        /// Add a new user to customers list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns the id of the recently added customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // generate new Guuid
                customer.CustomerId = Guid.NewGuid();

                // add customer
                Customers.Add(customer);

                return customer.CustomerId;
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
        /// Updates an existing customers details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Deteminers whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                // find existing customer by CustomerId
                Customer existingCustomer = Customers.Find(item => item.CustomerId == customer.CustomerId);
            
                // update all details
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.Mobile = customer.Mobile;

                    return true;
                } 
                else
                {
                    return false;
                }
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
        /// Deletes an existing customer based on CustomerId
        /// </summary>
        /// <param name="customerId">CustomerId to delete</param>
        /// <returns>Returns a bool indication if user is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                // delete customer by CustomerId
                if (Customers.RemoveAll(customer => customer.CustomerId == customerId) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
