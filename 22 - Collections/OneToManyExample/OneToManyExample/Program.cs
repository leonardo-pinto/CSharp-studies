using System;
using System.Collections.Generic;
using College;

namespace OneToManyExample
{
    class Program
    {
        static void Main()
        {
            Student student = new Student();
            student.RollNo = 1;
            student.StudentName = "Josias";
            student.Email = "josias@mail.com";
            student.Examinations = new List<Examination>();
            student.Examinations.Add(new Examination()
            {
                ExaminationName = "Module 1",
                Month = 1,
                Year = 1990,
                MaxMarks = 5,
                SecuredMarks = 3
            }
            );


            Console.WriteLine(student.RollNo);
            Console.WriteLine(student.StudentName);
            Console.WriteLine(student.Email);

            foreach (Examination examination in student.Examinations)
            {
                Console.WriteLine(examination.ExaminationName);
                Console.WriteLine(examination.Year);
            }

            Console.ReadKey();
        }
    }
}
