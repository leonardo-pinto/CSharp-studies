using System;

public class Manager : IEmployee, IPerson
{
    // instance fields
    // private int _id;
    // private string _name;
    // private string _location;

    // properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public System.DateTime DateOfBirth { get; set; }

    // constructor
    public Manager(int id, string name, string location, string dateOfBirth)
    {
        Id = id;
        Name = name;
        Location = location;
        DateOfBirth = System.Convert.ToDateTime(dateOfBirth);
    }

    public string GetHealthInsuranceAmount()
    {
        return "Health insurance amount: 500";
    }

    public int GetAge()
    {
        int age = System.Convert.ToInt32((System.DateTime.Now - DateOfBirth).TotalDays / 365);
        return age;
    }
}
