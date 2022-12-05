class Program
{
    static void Main()
    {
        byte a = 10;

        int b = 10;

        string c = "10.34";

        // implicit casting
        // convert to "short" type
        short aShort = a;
        System.Console.WriteLine("a implicit casting: " + aShort);

        // explicit casting
        short bShort = (short) b;
        System.Console.WriteLine("b explicit casting: " + bShort);

        // parse or TryParse
        decimal.TryParse(c, out decimal d);
        System.Console.WriteLine("c try parse" + d);

        // conversion methods
        double e = 10.55;
        string eString = System.Convert.ToString(e);
        System.Console.WriteLine("eString: " + eString);
        System.Console.ReadKey();
    }
}