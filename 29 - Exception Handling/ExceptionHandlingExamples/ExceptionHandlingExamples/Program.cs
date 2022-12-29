﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingExamples
{
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double CurrentBalance { get; set; }
    }

    class FundasTranfer
    {
        public void Transfer(BankAccount sourceAccount, BankAccount destinationAccount, double amount)
        {
            // can use one try block to personalize each throw statement
            try
            {
                // if source or destinationAccount is null
                // it throws a NullReferenceException
                sourceAccount.CurrentBalance -= amount;
                destinationAccount.CurrentBalance += amount;
            }
            catch (NullReferenceException)
            {
                // proper information to the method caller
                throw new ArgumentNullException("sourceAccount", "Null parameters were entered");
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            try
            {
                BankAccount account1 = new BankAccount() { AccountNumber = 1, AccountHolderName = "Bob", CurrentBalance = 10000 };
                BankAccount account2 = new BankAccount() { AccountNumber = 2, AccountHolderName = "Jose", CurrentBalance = 40000 };
                // will result in a NullReferenceException
                BankAccount account3 = null;

                FundasTranfer fundsTranfers = new FundasTranfer();
                fundsTranfers.Transfer(account2, account1, 500);
                // throws NullReferenceException
                // we throw ArgumentNullException to the client
                fundsTranfers.Transfer(account3, account1, 90);

                Console.WriteLine(account1.AccountHolderName + ", " + account1.CurrentBalance);
                Console.WriteLine(account2.AccountHolderName + ", " + account2.CurrentBalance);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadKey();
        }
    }
}
