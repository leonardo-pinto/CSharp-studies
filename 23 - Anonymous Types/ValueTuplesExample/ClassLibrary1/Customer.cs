using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Customer
    {
        // example of tuple value as return type
        public (int customerId, string customerName) GetCustomerDetails()
        {
            return (101, "Scott");
        }
    }
}
