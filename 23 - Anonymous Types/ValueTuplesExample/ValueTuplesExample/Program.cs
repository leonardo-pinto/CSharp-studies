using System;
using System.Collections.Generic;
using ClassLibrary1;


namespace ValueTuplesExample
{
    internal class Program
    {
        static void Main()
        {
            Customer customer= new Customer();

            (int customerId, string customerName) cust = customer.GetCustomerDetails();

            Console.WriteLine(cust.customerName);
            Console.WriteLine(cust.customerId);

            Console.ReadKey();
        }
    }
}
