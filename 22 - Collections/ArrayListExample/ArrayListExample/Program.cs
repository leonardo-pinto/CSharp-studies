using System;
using System.Collections.Generic;
using System.Collections;

namespace ArrayListExample
{
    public class Employee
    {
        public string Name { get; set; }
    }


    internal class Program
    {
        static void Main()
        {
            // create object of ArrayList class
            ArrayList arrayList = new ArrayList()
            { 1, "any text" };

            arrayList.Add(1.1);

            Employee emp = new Employee() { Name = "Joseph Richards" };

            arrayList.Add(emp);

            foreach(var item in arrayList)
            {
                if (item is Employee employee)
                {
                    Console.WriteLine(employee.Name);
                }
                else
                {
                    Console.WriteLine(item);
                };
            }

            Console.ReadKey();
        }
    }
}
