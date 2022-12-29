using System;
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

    class FundsTranfer
    {
        public void Transfer(BankAccount sourceAccount, BankAccount destinationAccount, double amount)
        {
            // can use one try block to personalize each throw statement
            try
            {
                // if source or destinationAccount is null
                // it throws a NullReferenceException
                // it is handle as a InnerException
                sourceAccount.CurrentBalance -= amount;
                destinationAccount.CurrentBalance += amount;
            }
            catch (NullReferenceException ex)
            {
                // proper information to the method caller
                throw new ArgumentNullException("You have supplied null values", ex);
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

                FundsTranfer fundsTranfers = new FundsTranfer();
                fundsTranfers.Transfer(account2, account1, 500);
                // throws NullReferenceException
                // we throw ArgumentNullException to the client
                fundsTranfers.Transfer(account3, account1, 90);

                Console.WriteLine(account1.AccountHolderName + ", " + account1.CurrentBalance);
                Console.WriteLine(account2.AccountHolderName + ", " + account2.CurrentBalance);
            }
            catch (ArgumentNullException exc)
            {
                // message from ArgumentNullException
                Console.WriteLine(exc.Message);
                // message from NullReferenceException
                Console.WriteLine(exc.InnerException.Message);
            }
            Console.ReadKey();
        }
    }
}
