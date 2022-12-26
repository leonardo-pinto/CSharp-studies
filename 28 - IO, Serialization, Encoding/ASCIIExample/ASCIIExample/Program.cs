using static System.Console;
using System.Text;
using System;

namespace ASCIIExample
{
    internal class Program
    {
        static void Main()
        {
            char ch = 'a';

            // converting char to ascii value
            // int, long, decimal can be used too
            byte b = (byte)ch; // 97

            // convert to char value
            char convertToChar = (char)b; // 'a'

            WriteLine(b);

            WriteLine(convertToChar);

            byte[] bytes = new byte[128];
            for (byte index = 0; index < bytes.Length; index++)
            {
                bytes[index] = index;
            }

            string s = Encoding.ASCII.GetString(bytes); // byte[] to string
            OutputEncoding = Encoding.ASCII;
            WriteLine(s);

            string sentence = "Hello how are you";

            // string to byte[]
            // represents the sentence in ascii code
            byte[] bytesSentence = Encoding.ASCII.GetBytes(sentence);

            string sentence2 = Encoding.ASCII.GetString(bytesSentence);

            WriteLine(sentence2);

            ReadKey();
        }
    }
}
