class Program
{
    static void Main()
    {
        char grade = 'E';
        string classification;
        switch (grade)
        {
            case 'A':
                classification = "Excelent";
                break;
            case 'B':
                classification = "Good";
                break;
            case 'C':
                classification = "Fail";
                break;
            default:
                classification = "Try again";
                break;
        }

        System.Console.WriteLine("Grade classification is: " + classification);
        System.Console.ReadKey();
    }
}
