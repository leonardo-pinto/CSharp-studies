class Program
{
    static void Main()
    {
        Number number = new Number();
        number.SetValue(371);

        System.Console.WriteLine("Value: " + number.GetValue()); //Output: 371
        System.Console.WriteLine("IsZero: " + number.IsZero()); //Output: False
        System.Console.WriteLine("IsPositive: " + number.IsPositive()); //Output: True
        System.Console.WriteLine("IsNegative: " + number.IsNegative()); //Output: False
        System.Console.WriteLine("IsOdd: " + number.IsOdd()); //Output: True
        System.Console.WriteLine("IsEven: " + number.IsEven()); //Output: False
        System.Console.WriteLine("IsPrime: " + number.IsPrime()); //Output: False
        System.Console.WriteLine("GetCountOfDigits: " + number.GetCountOfDigits()); //Output: 3
        System.Console.WriteLine("GetSumOfDigits: " + number.GetSumOfDigits()); //Output: 11
        System.Console.WriteLine("GetReverse: " + number.GetReverse()); //Output: 173

        System.Console.ReadKey();
    }
}