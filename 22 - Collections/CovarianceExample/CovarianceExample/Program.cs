using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceExample
{

    class LivingThing
    {
        public int NumberOfLegs { get; set; }
    }

    class Bird: LivingThing
    {
    }

    class Dog: LivingThing
    {

    }

    interface IMover<out T>
    {
        // can not use T as argument type, only return
        T Move();
    }

    class Mover<T>: IMover<T> 
    {
        public T Thing { get; set; }
        public T Move()
        {
            return Thing;
        }
    }

    // real world scenario
    class Sample
    {
        public void PrintValues(List<string>values)
        {
            foreach(var item in values)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
        }
    }


    internal class Program
    {
        static void Main()
        {
            LivingThing livingThing= new Bird(); // not covariance
            Bird bird = new Bird() { NumberOfLegs = 2 }; //normal

            // Covariance is about supplying the child type name
            // where the parent type name is expected
            // works only on generic types
            IMover<LivingThing> mover = new Mover<Bird>() { Thing = bird };
            Console.WriteLine(mover.Move().NumberOfLegs);


            // real world scenario
            Sample s = new Sample();
            s.PrintValues(new List<string>() { "hello", "world" });
            Console.ReadKey();
        }
    }
}
