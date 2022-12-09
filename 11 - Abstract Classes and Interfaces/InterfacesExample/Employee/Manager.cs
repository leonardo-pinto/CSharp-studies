public class Manager : IEmployee
{
    // instance fields
    // private int _id;
    // private string _name;
    // private string _location;

    // properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    // constructor
    public Manager(int id, string name, string location)
    {
        Id = id;
        Name = name;
        Location = location;
    }

    public string GetHealthInsuranceAmount()
    {
        return "Health insurance amount: 500";
    }
}
