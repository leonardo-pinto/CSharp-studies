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

            // invoke the event
            publisher.RaiseEvent(10, 20);

            System.Console.ReadKey();

        }
    }
}
