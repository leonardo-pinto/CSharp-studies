public class Employee
{

    // instance fields
    private int _id;
    private string _name;
    private string _job;
    private readonly int _salary;
    private double _tax;
    // static field
    private static string _companyName;

    // instance properties
    public int Id
    {
        set { _id = value; }
        get { return _id; }
    }

    public string Name
    {
        set
        {
            if (value.Length >= 5)
            {
                _name = value;
            }
        }
        get { return _name; }
    }

    public string Job
    {
        set { _job = value; }
        get { return _job; }
    }

    public int Salary
    {
        // readonly property
        get
        {
            return _salary;
        }
    }

    public double Tax
    {
        // writeonly property
        set
        {
            if (value >= 0 && value < 100)
            {
                _tax = value;
            }
        }
    }

    // auto-implemented property
    public string Nationality
    {
        set;
        get;
    // initializer is a feature of C# 6.0
    // works like a default value when the class is created
    // it is overwritten if the set accessor is used
    } = "Undefined";

    // static property
    public static string CompanyName
    {
        set { _companyName = value; }
        get { return _companyName;  }
    }

    // instance constructor
    public Employee()
    {
        _salary = 500;
    }


    // with parameters
    public Employee(int id, string name, string job, int salary) 
    {
        _id = id;
        _name = name;
        _job = job;
        _salary = salary;
    }

    // methods
    public double CalculateNetSalary()
    {
        double netSalary = _salary - (_salary * (_tax / 100));
        return netSalary;
    }


}