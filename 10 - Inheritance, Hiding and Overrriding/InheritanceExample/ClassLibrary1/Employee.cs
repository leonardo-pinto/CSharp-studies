public class Employee
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Location { set; get; }

    public Employee(string id, string name, string location)
    {
        Id = id;
        Name = name;
        Location = location;
    }

    public string GetHealthInsuranceAmount()
    {
        return "Health insurance amount is: 600";
    }

    // method overriding
    public virtual string GetDentalPlanAmount()
    {
        return "Dental plan amount is: 500";
    }
}