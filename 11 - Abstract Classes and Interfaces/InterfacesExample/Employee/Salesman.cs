public class Salesman : IEmployee
{
    // fields
    private int _id;
    private string _name;
    private string _location;


    // properties
    public int Id 
    { 
        get
        {
            return _id;
        }
        set
        {
            this._id = value;
        }    
    }

    public string Name
    {
        get
        {
            return this._name;
        }
        set
        {
            this._name = value;
        }
    }

    public string Location
    {
        get
        {
            return this._location;
        }
        set
        {
            this._location = value;
        }
    }


    public Salesman(int id, string name, string location)
    {
        this._id = id;
        this._name = name;
        this._location = location;
    }

    public string GetHealthInsuranceAmount()
    {
        return "Health insurance amount: 300";
    }
}
