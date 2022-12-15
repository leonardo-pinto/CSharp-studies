namespace ClassLibrary1
{
    public class Student
    {
        // private fields
        private string _studentName;

        public Student(string studentName)
        {
            _studentName = studentName;
        }

        // example of constructors
        // public Student() => _studentName = "Example";

        // public method
        //public int GetStudentNameLength()
        //{
        //    return _studentName.Length;
        //}
        
        // expressions bodied method syntax
        public int GetStudentNameLength() => _studentName.Length;
    }
}
