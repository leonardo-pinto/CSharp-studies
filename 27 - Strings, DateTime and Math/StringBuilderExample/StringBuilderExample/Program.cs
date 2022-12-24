using System;
using System.Text;

namespace StringBuilderExample
{
    internal class Program
    {
        static void Main()
        {
            string[] words = new string[] { "Hello", "how", "are", "you", "?" };
            // StringBuilder
            StringBuilder builder = new StringBuilder();

            foreach(string word in words)
            {
                builder.Append(word);
                builder.Append(" ");
            }

            Console.WriteLine(builder.ToString());

            Console.ReadKey();
        }
    }
}
