using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeExample
{
    internal class Program
    {
        static void Main()
        {
            // \u indicates it is a unicode format
            string code = "\u0543";
            Console.WriteLine(code);


            string sentence = "Hello, how are you";

            byte[] sentenceInBytes = Encoding.Unicode.GetBytes(sentence);

            string sentenceInString = Encoding.Unicode.GetString(sentenceInBytes);

            Console.WriteLine(sentenceInString);

            Console.ReadKey();
        }
    }
}
