using System;
using College;

namespace OneToOneExample
{
    internal class Program
    {
        static void Main()
        {
            Student student = new Student();
            student.RollNo = 123;
            student.StudentName = "John Doe";
            student.Email = "john.doe@mail.com";

            Branch branch = new Branch();
            branch.BranchName = "Computer Science";
            branch.NoOfSemesters = 8;

            // one-to-one relation
            student.Branch = branch;

            Console.WriteLine(student.RollNo);
            Console.WriteLine(student.StudentName);
            Console.WriteLine(student.Email);
            Console.WriteLine(student.Branch.BranchName);
            Console.WriteLine(student.Branch.NoOfSemesters);

            Console.ReadKey();
        }
    }
}
