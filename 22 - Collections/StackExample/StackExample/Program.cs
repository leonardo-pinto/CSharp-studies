using System;
using System.Collections.Generic;
using System.Collections;

namespace StackExample
{
    class Student
    {
        public int Marks { get; set; }
        public int Rank { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            // create object of Stack
            Stack <Student> marks =  new Stack<Student>();

            // Add
            //marks.Push(45);
            //marks.Push(20);
            //marks.Push(90);
            marks.Push(new Student() { Marks = 45 });
            marks.Push(new Student() { Marks = 61 });
            marks.Push(new Student() { Marks = 20 });

            marks.Pop();

            // foreach
            foreach(Student student in marks)
            {
                Console.WriteLine(student.Marks);
            }

            Console.ReadKey();
        }
    }
}
