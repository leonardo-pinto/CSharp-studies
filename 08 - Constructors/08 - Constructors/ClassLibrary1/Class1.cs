public class Employee
{
    public int id;
    public string name;
    public string job;
    public static string companyName;

    public Employee(int id, string name, string job) 
    {
        this.id = id;
        this.name = name;
        this.job = job;
    }

    static Employee()
    {
        companyName = "L.A. Banks";
    }

}