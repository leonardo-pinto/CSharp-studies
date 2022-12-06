public class Employee
{

    // instance fields
    private int _id;
    private string _name;
    private string _job;
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

    // static property
    public static string CompanyName
    {
        set { _companyName = value; }
        get { return _companyName;  }
    }

    // instance constructor
    public Employee() { }


    // with parameters
    public Employee(int id, string name, string job) 
    {
        _id = id;
        _name = name;
        _job = job;
    }


}