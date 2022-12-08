public class Manager: Employee
{
    public string DepartmentName { get; set; }

    public Manager(string id, string name, string location, string departmentName) : base(id, name, location)
    {
        DepartmentName = departmentName;
    }

    public int GetTotalSalesOfYear()
    {
        return 5000;
    }

    // override abstract method from parent class
    public override string GetHealthInsuranceAmount()
    {
        return "Health insurance amount is: 750";
    }

}