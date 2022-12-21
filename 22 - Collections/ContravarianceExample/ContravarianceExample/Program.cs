using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContravarianceExample
{
    class LivingThing 
    { 
        public int NumberOfLegs { get; set; }
    }

    class Bird : LivingThing { }
    class Dog : LivingThing { }

    interface IMover<in T>
    {
        void Move(T x);
    }

    public class Mover<T>: IMover<T>
    {
        public void Move(T x)
        {
            if (x is Bird)
                Console.WriteLine("Moving with " + (x as Bird).NumberOfLegs + " legs");
        }
    }
    internal class Program
    {
        static void Main()
        {
            // create normal object
            Bird bird = new Bird() { NumberOfLegs = 2 };
            Dog dog = new Dog();

            IMover<Bird> obj1 = new Mover<Bird>(); // normal

            // Contravariance supplies the parent type name,
            // where the child name is expected
            IMover<Bird> obj2 = new Mover<LivingThing>(); // contravariance

            obj2.Move(bird);

            Console.ReadKey();
        }
    }
}
