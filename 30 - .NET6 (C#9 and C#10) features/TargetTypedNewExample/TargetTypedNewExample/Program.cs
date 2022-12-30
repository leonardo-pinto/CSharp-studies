class Student
{
    public string? Name { get; set; } = "Joseph Richards";
}

class Program
{
    static void Main()
    {
        Student student = new();

        Console.WriteLine(student.Name);
    }
}