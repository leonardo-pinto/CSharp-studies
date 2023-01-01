using PartialMethodsExample;

class Program
{
    static void Main()
    {
        Student student = new();
        student.StudentId = 10;

        //Console.WriteLine(student.StudentId);
        Console.WriteLine(student.GetStudentID());
    }
}