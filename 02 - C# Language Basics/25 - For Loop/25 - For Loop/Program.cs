class Program
{
    static void Main()
    {
        // for (initialization; condition; incrementation
        for (int i = 0; i <= 10; i++)
        {
            // System.Console.WriteLine("Index value is: " + i);
        }

        // System.Console.ReadKey();


        // Task 7
        for (int i = 1; i <= 10; i++)
        {
            if (i > 3 && i <= 7)
            {
                for (int k = 10; k >= 1; k--)
                {
                    if (i == 6 && k <= 2)
                    {
                        break;
                    }
                    System.Console.Write(k);
                    System.Console.Write(' ');
                }
            } else if (i > 8)
            {
                break;
            }
            else
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (j == 5 || j == 6)
                    {
                        continue;
                    }
                    System.Console.Write(j);
                    System.Console.Write(' ');
                }
            }
            System.Console.WriteLine();
        }
        System.Console.ReadKey();
    }
}