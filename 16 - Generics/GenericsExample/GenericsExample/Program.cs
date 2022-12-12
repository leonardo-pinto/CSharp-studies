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
        
        // generic constraints example
        // create object of generic class with constaints
        MarksPrinter<GraduateStudent> marksPrinter = new MarksPrinter<GraduateStudent>();
        marksPrinter.student = new GraduateStudent() { Marks = 10};
        marksPrinter.PrintMarks();


        // generic method example
        Employee employee = new Employee() { salary = 1000 };
        Manager manager = new Manager() { tax = 12 };
        Sample sample = new Sample();
        // <Employee> is optional
        sample.PrintData<Employee>(employee);
        sample.PrintData(manager);
        sample.PrintData(sample);

        ReadKey();
    }
}