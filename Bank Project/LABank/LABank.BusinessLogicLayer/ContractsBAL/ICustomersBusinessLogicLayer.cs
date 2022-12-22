using System;
using System.Collections.Generic;
using LABank.Entities;

namespace LABank.BusinessLogicLayer.ContractsBAL
{
    /// <summary>
    /// Interface that represents customers business logic
    /// </summary>
    public interface ICustomersBusinessLogicLayer
    {
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of costumers</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

        /// <summary>
        /// Adds a new customer to the existing customer list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns the id of the recently added customer</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to updated</param>
        /// <returns>Returns a bool indication if user is updated successfully</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">Customer ID to delete</param>
        /// <returns>Returns a bool indication if user is deleted successfully</returns>
        bool DeleteCustomer(Guid customerId);
    }
}
