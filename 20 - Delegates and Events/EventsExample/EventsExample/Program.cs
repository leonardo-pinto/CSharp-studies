using ClassLibrary1;

namespace EventsExample
{
    internal class Program
    {
        static void Main()
        {
            // create object of Subscriber class
            Subscriber subscriber = new Subscriber();

            // create class of Publisher class
            Publisher publisher = new Publisher();

            // handle the event (or) subscribe to event
            publisher.myEvent += subscriber.Add;

            // example of anonymous methods
            publisher.myEvent += delegate (int a, int b)
            {
                System.Console.WriteLine("Anonymous method multiplication: " + (a * b));
            };

            // example of lambda expressions
            // doest not required parameters type
            publisher.myEvent += (a, b) =>
            {
                System.Console.WriteLine("Lamba expression subtraction: " + (a - b));
            };

            // example of lambda expressions
            // must return a value
            // publisher.myEvent += (a, b) => a + b;

            // invoke the event
            publisher.RaiseEvent(10, 20);

            System.Console.ReadKey();

        }
    }
}
