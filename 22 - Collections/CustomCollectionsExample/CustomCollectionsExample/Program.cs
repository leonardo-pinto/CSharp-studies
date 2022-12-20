using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionsExample
{
    public enum TypeOfCostumer
    {
        RegularCostumer, VIPCostumer
    }

    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public TypeOfCostumer CustomerType { get; set; }
    }

    public class CustomersList: IEnumerable
    {
        private List<Customer> customers = new List<Customer>()
        {
            new Customer(){ CustomerId = "A", CustomerName = "Joseph", CustomerType = TypeOfCostumer.VIPCostumer },
            new Customer(){ CustomerId = "AB", CustomerName = "Josephina", CustomerType = TypeOfCostumer.VIPCostumer },
            new Customer(){ CustomerId = "aC", CustomerName = "Josephino", CustomerType = TypeOfCostumer.VIPCostumer },
        };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index< customers.Count; index++)
            {
                yield return customers[index];
            }
        }

        public void Add(Customer customer)
        {
            if (customer.CustomerId.StartsWith("A") || customer.CustomerId.StartsWith("a"))
            {
                customers.Add(customer);
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }

        }
    }
    
    internal class Program
    {
        static void Main()
        {
            CustomersList customersList = new CustomersList();


            // create new Customer object
            Customer newCustomer = new Customer()
            {
                CustomerId = "AcC",
                CustomerName = "Dale",
                CustomerType = TypeOfCostumer.RegularCostumer
            };

            customersList.Add(newCustomer);
        
            foreach (Customer customer in customersList)
            {
                Console.WriteLine(customer.CustomerId);
            }

            Console.ReadKey();
        }
    }
}
