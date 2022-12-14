abstract public class Employee
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

    // abstract method has no body
    public abstract string GetHealthInsuranceAmount();


    // method overriding
}