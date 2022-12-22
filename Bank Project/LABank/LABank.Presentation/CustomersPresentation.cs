using LABank.BusinessLogicLayer;
using LABank.BusinessLogicLayer.ContractsBAL;
using LABank.Entities;
using LABank.Entities.Contracts;
using System;
using System.Collections.Generic;

namespace LABank.Presentation
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                // create an object of Customer
                Customer customer = new Customer();

                // read all details from the user
                Console.WriteLine("\n ****** ADD CUSTOMER ******");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                // create BL object
                // it is best practice to call through the interface
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                Guid newCustomerGuid = customersBusinessLogicLayer.AddCustomer(customer);
                
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerId == newCustomerGuid);
                
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added. \n");
                }
                else
                {
                    Console.WriteLine("Customer Not Added.");
                }
            }
            catch (Exception exception)
            {
                // Should not throw exception in presentation layer
                // must display appropriate message to user
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.GetType());
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> customersList = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n ****** ALL CUSTOMERS ******");
                // read all customers
                foreach(Customer customer in customersList)
                {
                    Console.WriteLine("Customer Code: " + customer.CustomerCode);
                    Console.WriteLine("Customer Name: " + customer.CustomerName);
                    Console.WriteLine("Customer Address: " + customer.Address);
                    Console.WriteLine("Customer Landmark: " + customer.Landmark);
                    Console.WriteLine("Customer City: " + customer.City);
                    Console.WriteLine("Customer Country: " + customer.Country);
                    Console.WriteLine("Customer Mobile: " + customer.Mobile);
                    Console.WriteLine();
                }
            }
            catch (Exception exception)
            {
                // Should not throw exception in presentation layer
                // must display appropriate message to user
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.GetType());
            }
        }

        internal static void DeleteCustomer()
        {
            try
            {
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                Console.WriteLine("\n ****** DELETE CUSTOMER ******");
                Console.Write("Customer Code: ");
                long currCustomerCode = System.Convert.ToInt32(Console.ReadLine());

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == currCustomerCode);

                if (matchingCustomers.Count >= 1)
                {
                    bool isCustomerDeleted = customersBusinessLogicLayer.DeleteCustomer(matchingCustomers[0].CustomerId);
                    if (isCustomerDeleted)
                    {
                        Console.WriteLine("Customer deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Customer not deleted. \n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid customer code");
                }
            }
            catch (Exception exception)
            {
                // Should not throw exception in presentation layer
                // must display appropriate message to user
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.GetType());
            }
        }
    }
}
