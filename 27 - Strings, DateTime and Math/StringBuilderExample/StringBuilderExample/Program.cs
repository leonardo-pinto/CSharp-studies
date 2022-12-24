using System;
using System.Text;

namespace StringBuilderExample
{
    internal class Program
    {
        static void Main()
        {
            string[] words = new string[] { "Hello", "how", "are", "you", "?", "I", "am", "fine" };
            // StringBuilder
            StringBuilder builder = new StringBuilder(20);

            foreach(string word in words)
            {
                builder.Append(word);
                builder.Append(" ");

                Console.WriteLine(builder.ToString() + ", " + builder.Length + ", " + builder.Capacity);
            }

            Console.WriteLine(builder.ToString());

            Console.ReadKey();
        }
    }
}
