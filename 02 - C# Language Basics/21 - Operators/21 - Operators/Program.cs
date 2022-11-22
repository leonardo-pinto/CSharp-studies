class Program
{ 
    static void Main()
    {
        int a = 10;
        int b = 5;
        int c = 3;

        System.Console.WriteLine(a > b); // Output: true
        System.Console.WriteLine(b == c); // Output: false
        System.Console.WriteLine(a > b && a > c); // Output: true
        System.Console.WriteLine(b > c ? "Yes" : "No"); // "Yes"
        System.Console.WriteLine(b > c ^ a > b); // "False"
        System.Console.ReadKey();

        // Calculate a circle area
        int r = 10;
        double pi = 3.14159;

        double area = pi * r * r;
        System.Console.WriteLine("The circle area is: " + area);
        System.Console.ReadKey();

        // Convert Seconds into Minutes
        int seconds = 288970;
        int remaining_seconds = seconds;
        int seconds_per_minutes = 60;
        int seconds_per_hours = 60 * 60;
        int seconds_per_day = 60 * 60 * 24;
        System.Console.WriteLine("Seconds per day: " + seconds_per_day);
        int days = seconds / seconds_per_day;
        remaining_seconds -= days * seconds_per_day;

        int hours = remaining_seconds / seconds_per_hours;
        remaining_seconds -= hours * seconds_per_hours;

        int minutes = remaining_seconds / seconds_per_minutes;
        remaining_seconds -= minutes * seconds_per_minutes;

        System.Console.WriteLine(days + " days, " + hours + " hours, " + minutes + " minutes, " + remaining_seconds + " seconds");
        System.Console.ReadKey();



    }
}