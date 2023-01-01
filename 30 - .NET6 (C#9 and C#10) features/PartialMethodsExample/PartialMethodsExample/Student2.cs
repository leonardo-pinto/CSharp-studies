using System;

namespace PartialMethodsExample
{
    partial class Student
    {
        public int StudentId
        {
            // as a partial class, the fields and properties
            // can be assessed through the other partial class
            get => _studentId;
            set => _studentId = value;
        }

        // partial method implementation
        public partial int GetStudentID()
        {
            return StudentId;
        }
    }
}
