using ClassLibrary1;
using System;

namespace ExpressionBodiedMethods
{
    internal class Program
    {
        static void Main()
        {
            Student student = new Student("Leonardo") ;

            Console.WriteLine(student.GetStudentNameLength());
            Console.ReadKey();
        }
    }
}
