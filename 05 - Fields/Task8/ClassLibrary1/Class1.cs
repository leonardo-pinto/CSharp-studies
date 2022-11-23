public class Employee
{
    public int empId;
    public string empName;
    public int salaryPerHour;
    public int noOfWorkingHours;
    public int netSalary;
    public static string organizationName;
    public const string typeOfEmployee = "Contract Based";
    public readonly string departmentName;

    public Employee()
    {
        departmentName = "Finance Department";
    }
}