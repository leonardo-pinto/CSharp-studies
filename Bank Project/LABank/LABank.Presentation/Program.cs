using LABank.Presentation;

class Program
{
    static void Main()
    {
        // displays title
        System.Console.WriteLine("******** LA Bank ********");
        System.Console.WriteLine(":: Login Page ::");

        // declare variables to store username and password
        string userName = null;
        string password = null;

        // read userName from keyboard
        System.Console.Write("Username: ");
        userName = System.Console.ReadLine();

        // read password from keyboard if userName is not empty
        if (userName != "")
        {
            System.Console.Write("Password: ");
            password = System.Console.ReadLine();
        }

        // check userName and password
        if (userName == "system" && password == "manager")
        {
            int mainMenuChoice;
            do
            {
                // shows main menu
                System.Console.WriteLine("\n::: Main menu :::");
                System.Console.WriteLine("1. Customers");
                System.Console.WriteLine("2. Accounts");
                System.Console.WriteLine("3. Funds Transfer");
                System.Console.WriteLine("4. Funds Transfer Statement");
                System.Console.WriteLine("5. Account Statement");
                System.Console.WriteLine("0. Exit");

                // get menu choice from keyboard
                System.Console.Write("Enter choice: ");
                mainMenuChoice = int.Parse(System.Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1: CustomersMenu();
                        break;
                    case 2: AccountsMenu();
                        break;
                    case 3: // TO DO: display funds transfer menu
                        break;
                    case 4: // TO DO: display funds transfer statement menu
                        break;
                    case 5: // TO DO: display account statement menu
                        break;
                }
            } while (mainMenuChoice != 0);

        }
        else
        {
            System.Console.WriteLine("Invalid username or password");
        }

        // about to exit
        System.Console.WriteLine("Thank you for your visit. See you next time");
        System.Console.ReadKey();
    }

    static void CustomersMenu()
    {
        // variable to store customers menu choice
        int customerMenuChoice;

        do
        {
            System.Console.WriteLine("\n::: Customers menu :::");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("4. View Customers");
            System.Console.WriteLine("5. Search Customer");
            System.Console.WriteLine("0. Back to Main Menu");

            // get customers menu choice
            System.Console.Write("Enther choice: ");
            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            switch (customerMenuChoice)
            {
                case 1: CustomersPresentation.AddCustomer(); break;
                case 2: CustomersPresentation.DeleteCustomer(); break;
                case 3: CustomersPresentation.UpdateCustomer(); break;
                case 4: CustomersPresentation.ViewCustomers(); break;
                default:
                    break;
            }


        } while (customerMenuChoice != 0);
    }

    static void AccountsMenu()
    {
        // variable to store customers menu choice
        int accountsMenuChoice;

        do
        {
            System.Console.WriteLine("\n::: Accounts menu :::");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Accounts");
            System.Console.WriteLine("0. Back to Main Menu");

            // get accounts menu choice
            System.Console.Write("Enther choice: ");
            accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());
        } while (accountsMenuChoice != 0);
    }
}