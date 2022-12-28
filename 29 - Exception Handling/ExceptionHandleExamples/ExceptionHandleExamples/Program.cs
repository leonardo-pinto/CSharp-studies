using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandleExamples
{
    class BankAccount
    {
        public string HolderName { get; set; }
        public int Number { get; set; }
        public double CurrentBalance { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            try
            {
                //FormatException

                BankAccount bankAccount = new BankAccount();

                Console.Write("Enter account holder name: ");
                bankAccount.HolderName = Console.ReadLine();
                Console.Write("Enter account number: ");

                // when parsing strings, space or special characters
                bankAccount.Number = int.Parse(Console.ReadLine());
                Console.Write("Enter account current balance: ");
                bankAccount.CurrentBalance = double.Parse(Console.ReadLine());

                Console.WriteLine("\nNew bank account details:");
                Console.WriteLine("Holder name: " + bankAccount.HolderName);
                Console.WriteLine("Account number: " + bankAccount.Number);
                Console.WriteLine("Current balance: " + bankAccount.CurrentBalance);

            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadKey();
        }
    }
}
