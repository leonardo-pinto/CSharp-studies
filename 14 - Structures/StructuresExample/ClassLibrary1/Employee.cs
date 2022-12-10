// example of a readonly structure
// all fields must be readonly
public readonly struct Employee
{
    private readonly int _id;

    public int Id { get { return _id; } }

    public Employee(int id)
    {
        _id = id;
    }
}
