using System;

namespace PartialMethodsExample
{
    partial class Student
    {
        private int _studentId;


        // partial method declaration
        // before c#, by default is private, parameterless and void
        // if modifier is different than private
        // it must implement method in all other partial classes
        public partial int GetStudentID();
    }

}
