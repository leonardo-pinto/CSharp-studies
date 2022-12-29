using System;
using System.Collections.Generic;
using System.Linq;

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
            //// FormatException example
            //try
            //{
            //    BankAccount bankAccount = new BankAccount();

            //    Console.Write("Enter account holder name: ");
            //    bankAccount.HolderName = Console.ReadLine();
            //    Console.Write("Enter account number: ");

            //    // when parsing strings, space or special characters
            //    bankAccount.Number = int.Parse(Console.ReadLine());
            //    Console.Write("Enter account current balance: ");
            //    bankAccount.CurrentBalance = double.Parse(Console.ReadLine());

            //    Console.WriteLine("\nNew bank account details:");
            //    Console.WriteLine("Holder name: " + bankAccount.HolderName);
            //    Console.WriteLine("Account number: " + bankAccount.Number);
            //    Console.WriteLine("Current balance: " + bankAccount.CurrentBalance);

            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}

            //Console.ReadKey();

            //IndexOutOfRangeException

            try
            {
                BankAccount[] accounts = new BankAccount[]
                {
                   new BankAccount(){ HolderName = "Joseph", Number = 1, CurrentBalance = 100 },
                   new BankAccount(){ HolderName = "Joseph Richards", Number = 1, CurrentBalance = 100 },
                   new BankAccount(){ HolderName = "Joseph Urso", Number = 1, CurrentBalance = 100 },
                };

                for (int i = 0; i < accounts.Length; i++)
                {

                    Console.WriteLine($"{i + 1}. {accounts[i].HolderName}");
                }

                int selectedNumber;
                Console.Write("Enter holder index number: ");
                selectedNumber = int.Parse(Console.ReadLine());
                selectedNumber--;
                if (selectedNumber <= 0 || selectedNumber >= accounts.Length) {
                    Console.WriteLine("Invalid serial number");
                }
                else
                {
                    Console.WriteLine(accounts[selectedNumber].HolderName);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
