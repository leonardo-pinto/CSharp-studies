using ClassLibrary1;
using System;

namespace ArrayMethodsExample
{
    internal class Program
    {
        static void Main()
        {
            // create array
            int[] numbersArray = new int[3] {1, 2, 3};

            // search for 2 in the array
            // example of IndexOf
            Console.WriteLine("IndexOf 2: " + Array.IndexOf(numbersArray, 2));
            Console.WriteLine("Unexistent indexOf: " + Array.IndexOf(numbersArray, 50));
            
            // example of BinarySearch
            // can only be used in sorted arrays
            Console.WriteLine(Array.BinarySearch(numbersArray, 3));

            // example of Clear method
            int[] arrayToBeCleared = new int[5] { 1, 2, 3, 4, 5 };
            Array.Clear(arrayToBeCleared, 2, 3);
            
            foreach (int element in arrayToBeCleared)
            {
                Console.WriteLine(element);
            }

            // example of Resize method
            // increase/decrease array with null values
            int[] resizeExample = new int[2] { 1, 2 };
            Array.Resize(ref resizeExample, 5);

            foreach (int element in resizeExample)
            {
                Console.WriteLine(element);
            }

            // example of Sort method
            int[] arrayToBeSorted = new int[8] { 52, 48, 432, 1, 986, 358, 224, 985 };
            Console.WriteLine();
            Array.Sort(arrayToBeSorted);
            Console.WriteLine("Example of Sort method");
            foreach (int element in arrayToBeSorted)
            {
                Console.WriteLine(element);
            }

            // example of Reverse method
            int[] arrayToBeReversed = new int[3] { 1, 2, 3 };
            Console.WriteLine();
            Array.Reverse(arrayToBeReversed);

            Console.WriteLine("Example of Reverse method");
            foreach (int element in arrayToBeReversed)
            {
                Console.WriteLine(element);
            }

            // example of multi-dimensional arrays
            // multi-dim array 2 x 3
            Console.WriteLine("Example of multi-dim array");
            int[,] multiDimensionalArray = new int[4, 3]
            {
                // rows
                {1, 1, 1 },
                {2, 2, 2 },
                {3, 3, 3 },
                {4, 4, 4 }
            }; 

            // read data from multi-dim array
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(multiDimensionalArray[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            // example of jagged arrays
            // i.e., array of arrays
            Console.WriteLine("Example of jagged arrays");
            int[][] jaggedArrays = new int[2][];
            jaggedArrays[0] = new int[3] {0,1,2};
            jaggedArrays[1] = new int[5] {5,9,4,8,6}; 

            // read jagged arrays
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < jaggedArrays[i].Length; j++)
                {
                    Console.Write(jaggedArrays[i][j]);
                    Console.Write("");
                }
                Console.WriteLine();
            }

            // example of array of objects
        
            // create array of employees
            Employee[] employees = new Employee[]
            { 
                new Employee() { EmpID = 1, EmpName = "John Doe" },
                new Employee() { EmpID = 2, EmpName = "Leonardo" },
                new Employee() { EmpID = 3, EmpName = "Joseph Richards" },
            };

            // foreach loop for array of objects
            foreach(Employee employee in employees)
            {
                Console.WriteLine("ID: " + employee.EmpID);
                Console.WriteLine("Name: " + employee.EmpName);
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
