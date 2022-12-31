class BankAccount
{
    private readonly int _accountNumber;
    private readonly double _currentBalance;

    public int AccountNumber { get => _accountNumber; }
    public double CurrentBalance { get => _currentBalance; } 

    public BankAccount(int accountNumber, double currentBalance)
    {
        _accountNumber = accountNumber;
        _currentBalance = currentBalance;
    }
}

class DataStorage
{

    // developer 1
    public static List<BankAccount> GetBankAccounts()
    {
        return new List<BankAccount>()
        {
            new BankAccount(1, 1000),
            new BankAccount(2, 2000),
        };
    }

    // developer 2
    public static double GetCurrentBalance(BankAccount bankAccount)
    {
        // compilation error if property is readonly
        // bankAccount.AccountNumber = 100; // unexpected change
        return bankAccount.CurrentBalance;
    }
}

class Program
{
    static void Main()
    {
        List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
        BankAccount firstBankAccount = bankAccounts[0];

        Console.WriteLine($"Initial values: {firstBankAccount.AccountNumber}, {firstBankAccount.CurrentBalance}");
        double balance = DataStorage.GetCurrentBalance(firstBankAccount);
        Console.WriteLine("Final values: " + firstBankAccount.AccountNumber + ", " + balance);
        
    }
}

