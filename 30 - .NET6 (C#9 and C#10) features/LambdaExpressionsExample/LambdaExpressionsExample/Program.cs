class Program
{
    static void Main()
    {
        var getMessage = () => "Hello world";
        // scenario 1
        // alternative Func<int, object> getResult = (marks) => //..
        var getResult = object (int marks) =>
        {
            if (marks >= 35)
            {
                return "Pass";
            }
            else
            {
                return 0;
            }
        };

        Console.WriteLine(getResult(40));

        // scenario 2
        var GetNumbers = IList<int>() => new int[] { 1, 2, 3 };

        foreach(int number in GetNumbers())
        {
            Console.WriteLine(number);
        }
    }
}