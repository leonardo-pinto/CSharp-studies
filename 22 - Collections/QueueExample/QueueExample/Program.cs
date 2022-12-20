using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExample
{
    internal class Program
    {
        static void Main()
        {
            // create an object of Queue class
            Queue<string> queue = new Queue<string>();

            // enqueue (add)
            queue.Enqueue("Task 1");
            queue.Enqueue("Task 2");
            queue.Enqueue("Task 3");

            // foreach
            foreach(string item in queue)
            {
                Console.WriteLine(item);
            };

            // dequeue (remove)
            string dequeuedItem = queue.Dequeue();
            Console.WriteLine("Dequeued item " + dequeuedItem);

            // Peek
            // return next element
            string peekExample = queue.Peek();
            Console.WriteLine("Peek: " + peekExample);
            Console.ReadKey();

        }
    }
}
