using System.Collections.Generic;

namespace College
{
    public class Student
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public List<Examination> Examinations { get; set; }
    }
}
