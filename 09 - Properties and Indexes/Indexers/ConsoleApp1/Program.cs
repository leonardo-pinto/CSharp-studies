class Program
{
    static void Main()
    {
        Car car = new Car();
        System.Console.WriteLine(car[0]);
        car[0] = "Hyundai";
        System.Console.WriteLine(car[0]);


        System.Console.ReadKey();
    }
}