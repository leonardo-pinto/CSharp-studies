using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingExamples
{
    class BankAccount
    {
        private double _currentBalance;

        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double CurrentBalance {
            get => _currentBalance;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Current balance value must be positive");
                }
                _currentBalance = value;
            }
        }
    }

    class FundsTranfer
    {
        public void Transfer(BankAccount sourceAccount, BankAccount destinationAccount, double amount)
        {
            // can use one try block to personalize each throw statement
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException("amount", "Amount must a positive value");
                }

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
                BankAccount account1 = new BankAccount() { AccountNumber = 1, AccountHolderName = "Bob", CurrentBalance = -10000 };
                BankAccount account2 = new BankAccount() { AccountNumber = 2, AccountHolderName = "Jose", CurrentBalance = 40000 };
                // will result in a NullReferenceException
                BankAccount account3 = null;

                FundsTranfer fundsTranfers = new FundsTranfer();
                fundsTranfers.Transfer(account2, account1, 0);
                // throws NullReferenceException
                // we throw ArgumentNullException to the client
                fundsTranfers.Transfer(account3, account1, 90);

                Console.WriteLine(account1.AccountHolderName + ", " + account1.CurrentBalance);
                Console.WriteLine(account2.AccountHolderName + ", " + account2.CurrentBalance);
            }
            catch (ArgumentNullException ex)
            {
                // message from ArgumentNullException
                Console.WriteLine(ex.Message);

                // better to check if InnerException exists
                if (ex.InnerException != null)
                {
                    // message from NullReferenceException
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
