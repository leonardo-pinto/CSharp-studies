class Student
{
    public int RollNumer { get; set; }
    public List<int> Marks { get; set; }
}

class Teacher
{
    public static int MinPassMarksStatic { get; set; }
    public void GetMarksOfPassedSubjects()
    {
        Student student = new Student()
        {
            RollNumer = 1,
            Marks = new List<int>() { 100, 25, 36 }
        };

        int mininumPassMarksLocal = 35;

        // by adding static to the anonymous function
        // it is not possible to assess local variables
        // or method parameters
        // can only assess static or const properties
        // but not instance properties
        IEnumerable<int> passedMarks = student.Marks.Where(static mark => mark > MinPassMarksStatic);

        foreach(int item in passedMarks)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    static void Main()
    {
        Teacher teacher = new();
        teacher.GetMarksOfPassedSubjects();
    }
}