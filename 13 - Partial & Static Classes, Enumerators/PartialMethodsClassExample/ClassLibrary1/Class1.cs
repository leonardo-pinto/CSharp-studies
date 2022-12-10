// example of partial class
public partial class PartialClass
{
    // fields
    private int _id;

    // propreties
    public int Id { get { return _id; } }

    // methods
    public string GetExample()
    {
        return "method example";
    }
}