using System;
using System.Collections;
using System.Collections.Generic;


namespace namespace1
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

    public class CustomersList : ICollection<Customer>
    {
        private List<Customer> customers = new List<Customer>();

        public int Count => customers.Count;

        // returns true since property is private
        public bool IsReadOnly => true;

        // to avoid method overloading we used explicit interface implementation
        // public is not allowed, private default
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            for (int index = 0; index < customers.Count; index++)
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

        public void Clear()
        {
           customers.Clear();
        }

        public bool Contains(Customer item)
        {
            return customers.Contains(item);
        }

        public void CopyTo(Customer[] array, int arrayIndex)
        {
            customers.CopyTo(array, arrayIndex);
        }

        public bool Remove(Customer item)
        {
            return customers.Remove(item);
        }

        public Customer Find(Predicate<Customer> match)
        {
            return customers.Find(match);
        }

        public List<Customer> FindAll(Predicate<Customer> match)
        {
            return customers.FindAll(match);
        }
    }

    internal class Program
    {
        static void Main()
        {
            CustomersList customersList = new CustomersList();

            // create new Customer object
            Customer customer1 = new Customer()
            { CustomerId = "AcC", CustomerName = "Dale", CustomerType = TypeOfCostumer.RegularCostumer };

            Customer customer2 = new Customer()
            { CustomerId = "A", CustomerName = "Joseph", CustomerType = TypeOfCostumer.VIPCostumer };

            Customer customer3 = new Customer()
            { CustomerId = "AB", CustomerName = "Josephina", CustomerType = TypeOfCostumer.VIPCostumer };

            customersList.Add(customer1);
            customersList.Add(customer2);
            customersList.Add(customer3);

            // example of method usage
            Console.WriteLine("Customers found: " + customersList.Count);

            // Find
            Customer matchingCustomer = customersList.Find(customer => customer.CustomerName == "Josepxh");
            if (matchingCustomer != null)
            {
                Console.WriteLine("Customer found: " + matchingCustomer.CustomerName);
            }

            foreach (Customer customer in customersList)
            {
                Console.WriteLine(customer.CustomerId);
            }

            Console.ReadKey();
        }
    }
}
