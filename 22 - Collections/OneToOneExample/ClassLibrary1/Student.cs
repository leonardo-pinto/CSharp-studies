namespace College
{
    public class Student
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        // one-to-one object relation
        public Branch Branch { get; set; }
    }
}
