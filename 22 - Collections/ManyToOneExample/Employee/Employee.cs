using System;
using System.Collections.Generic;

namespace Company
{
    /// <summary>
    /// Represents an employee of the organizatio
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
    }
}
