using ClassLibrary1;
using static System.Console;

namespace PatternMatchingExample
{
    class Program
    {
        static void Main()
        {
            // reference variable of parent class
            ParentClass sample;

            // object of child class
            sample = new ChildClass() { X = 1, Y = 2 };

            // parent class type reference value !
            WriteLine(sample.X);
            // not possible to access Y field
            // WriteLine(sample.Y);

            // access parent class members
            //if (sample is ChildClass)
            //{
            //    WriteLine("If statement");
            //    ChildClass temp = (ChildClass)sample;
            //    WriteLine(temp.Y);
            //}
            if (sample is ChildClass temp)
            {
                WriteLine("If statement");
                WriteLine(temp.Y);
            }

            ReadKey();
        }
    }
}
