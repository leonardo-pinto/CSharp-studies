using static System.Console;

class Program
{
    static void Main()
    {
        // create object of generic class
        User<int> user1 = new User<int>();

        // using distinct field type to generic class
        User<bool> user2 = new User<bool>();

        // set value into generic field
        user1.registrationStatus = 1;
        user2.registrationStatus = false;

        WriteLine("User 1 registration status: " + user1.registrationStatus);
        WriteLine("User 2 registration status: " + user2.registrationStatus);
        ReadKey();
    }
}