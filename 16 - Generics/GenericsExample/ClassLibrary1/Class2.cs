public abstract class Student
{
    public abstract int Marks { get; set; }
}

public class GraduateStudent : Student
{
    public override int Marks { get; set; }
}

public class PostGraduateStudent : Student
{
    public override int Marks { get; set; }
}


// generic class with constraints (accepts Student or its child classes only)
public class MarksPrinter<T> where T : Student
{
    public T student;
    public void PrintMarks()
    {
        Student temp = (Student)student;
        System.Console.WriteLine("Print marks: " + temp.Marks);
    }
}