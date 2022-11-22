class Program
{
    static void Main()
    {
        int grade = 34;

        if (grade >= 50)
        {
            System.Console.WriteLine("Congratulations!");
        }
        else if (grade < 50 && grade >= 35)
         {
            System.Console.WriteLine("You almost did it!");
        }
        else
        {
            System.Console.WriteLine("Better luck next time");
        }

        System.Console.ReadKey();

        // Task 5: Height Category
        int inches = 75;
        double height = 2.54 * inches;
        string classification;

        if (height >= 195)
            classification = "Abnormal height";
        else if (height >= 165 && height < 195)
            classification = "Tall";
        else if (height >= 150 && height < 165)
            classification = "Average height";
        else
            classification = "Dwarf";
        System.Console.WriteLine("Height classification is: " + classification);
        System.Console.ReadKey();


        // Task 6: Largest of Three Numbers
        int num1 = 600;
        int num2 = 450;
        int num3 = 123;
        // Output = 123
        if (num3 > num2 && num3 > num1)
        {
            System.Console.WriteLine("The largest number is: " + num3);
        }
        else if (num2 > num3 && num2 > num1)
        {
            System.Console.WriteLine("The largest number is: " + num2);
        }
        else
        {
            System.Console.WriteLine("The largest number is: " + num1);
        }

        System.Console.ReadKey();
    }
}