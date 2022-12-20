using System;
using System.Collections.Generic;
using Company;

namespace ManyToOneExample
{
    internal class Program
    {
        static void Main()
        {
            // three employees in the same department;
            Employee emp1 = new Employee()
            { Id = 1, Name = "Josias", Email = "josias@mail.com" };
            Employee emp2 = new Employee()
            { Id = 2, Name = "Joseph", Email = "joseph@mail.com" };
            Employee emp3 = new Employee()
            { Id = 3, Name = "John", Email = "john@mail.com" };

            Department dep1 = new Department()
            { Id = 1, Name = "Physics" };

            emp1.Department = dep1;
            emp2.Department = dep1;
            emp3.Department = dep1;

        }
    }
}
