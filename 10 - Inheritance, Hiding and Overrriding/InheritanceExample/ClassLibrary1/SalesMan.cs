public class SalesMan: Employee
{
    public string Region { get; set; }

    public int GetSalesOfCurrentMonth()
    {
        return 500;
    }
}