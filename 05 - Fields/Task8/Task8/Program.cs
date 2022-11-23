class Program
{
    static void Main()
    {
        // initializes static field
        Employee.organizationName = "Harsha Inc.";

        System.Console.WriteLine("Welcome to Harsha Exployee Registrion!");

        for (int i = 0; i < 3; i++)
        {
            string employeeNumber;
            switch(i)
            {
                case 0:
                    employeeNumber = "FIRST EMPLOYEE:";
                    break;
                case 1:
                    employeeNumber = "SECOND EMPLOYEE:";
                    break;
                case 2:
                    employeeNumber = "THIRD EMPLOYEE:";
                    break;
                default:
                    employeeNumber = "OTHER EMPLOYEE:";
                     break;
            }

            System.Console.WriteLine(employeeNumber);

            Employee emp;
            emp = new Employee();

            // employee id from keyboard
            System.Console.Write("Employee ID: ");
            emp.empId = int.Parse(System.Console.ReadLine());

            // employee name from keyboard
            System.Console.Write("Employee name: ");
            emp.empName = System.Console.ReadLine();

            // employee salaryPerHour from keyboard
            System.Console.Write("Employee Salary Per Hour: ");
            emp.salaryPerHour = int.Parse(System.Console.ReadLine());

            // employee noOfWorkingHours from keyboard
            System.Console.Write("Employee Number of Working Hours: ");
            emp.noOfWorkingHours = int.Parse(System.Console.ReadLine());

            emp.netSalary = emp.salaryPerHour * emp.noOfWorkingHours;

            //display Employee Details
            System.Console.WriteLine("\nDETAILS OF " + employeeNumber);
            System.Console.WriteLine("Employee ID: " + emp.empId);
            System.Console.WriteLine("Employee Name: " + emp.empName);
            System.Console.WriteLine("Salary per Hour: " + emp.salaryPerHour);
            System.Console.WriteLine("No. of Working Hours: " + emp.noOfWorkingHours);
            System.Console.WriteLine("Net Salary: " + emp.netSalary);
            System.Console.WriteLine("Type of Employee: " + Employee.typeOfEmployee);
            System.Console.WriteLine("Department Name: " + emp.departmentName);

            System.Console.WriteLine("Do you want to continue to next employee? Y / N: ");
            string choice = System.Console.ReadLine();

            if (choice == "N")
            {
                break;
            }

        }

        System.Console.WriteLine("\nThank you.");
        System.Console.ReadKey();
    }
}