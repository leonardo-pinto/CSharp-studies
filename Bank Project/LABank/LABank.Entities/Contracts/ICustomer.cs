﻿using System;

namespace LABank.Entities
{
    public interface ICustomer
    {
        // global unique identifier
        Guid CustomerId { get; set; }
        long CustomerCode { get; set; }
        string Address { get; set; }
        string Landmark { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Mobile { get; set; }
    }
}
