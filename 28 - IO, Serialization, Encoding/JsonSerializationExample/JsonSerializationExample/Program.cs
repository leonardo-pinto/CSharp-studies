using System;
using System.IO;
using System.Runtime.Remoting;
using System.Web.Script.Serialization;


namespace JsonSerializationExample
{
    [Serializable]
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            //Employee employee = new Employee()
            //{
            //    Name = "Joseph Richards",
            //    Age = 56
            //};

            // Serialization

            //string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\employee.txt";
            //JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            //using (StreamWriter streamWriter = new StreamWriter(filePath))
            //{
            //    string serializedContent = jsSerializer.Serialize(employee);
            //    streamWriter.WriteLine(serializedContent);
            //    Console.WriteLine("File serialization");
            //};

            // Deserialization
            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\employee.txt";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                Employee employeeFromFile = jsSerializer.Deserialize(streamReader.ReadToEnd(), typeof(Employee)) as Employee;
                
                Console.WriteLine(employeeFromFile.Name+ " " + employeeFromFile.Age);
                
                Console.WriteLine("File deserialized");
            };

            Console.ReadKey();
        }
    }
}
