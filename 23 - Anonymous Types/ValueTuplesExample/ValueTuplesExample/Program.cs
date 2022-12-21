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

            // example of ValueTuple
            //(int customerId, string customerName) cust = customer.GetCustomerDetails();

            // example of tuple deconstructing
            // variable is deconstructed based on the order, not the property names
            (int customerId, string customerName) = customer.GetCustomerDetails();


            Console.WriteLine(customerName);
            Console.WriteLine(customerId);

            Console.ReadKey();
        }
    }
}
