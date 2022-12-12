using static System.Console;

class Program
{
    static void Main()
    {
        // create object of generic class
        User<int, int> user1 = new User<int, int>();

        // using distinct field type to generic class
        User<bool, int> user2 = new User<bool, int>();

        // set value into generic field
        user1.registrationStatus = 1;
        user1.age = 30;
        user2.registrationStatus = false;
        user2.age = 25;

        WriteLine("User 1 registration status: " + user1.registrationStatus);
        WriteLine("User 2 registration status: " + user2.registrationStatus);
        ReadKey();
    }
}