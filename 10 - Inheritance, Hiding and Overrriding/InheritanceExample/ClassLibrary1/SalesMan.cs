public class SalesMan: Employee
{
    public string Region { get; set; }

    public SalesMan(string id, string name, string location, string region): base(id, name, location)
    {
        Region = region;
    }

    public int GetSalesOfCurrentMonth()
    {
        return 500;
    }

    public new string GetHealthInsuranceAmount()
    {
        return "Health insurance amount is: 650";
    }
}