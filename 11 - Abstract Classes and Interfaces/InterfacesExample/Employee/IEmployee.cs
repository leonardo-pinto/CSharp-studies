// interface example

// interfaces naming starts with I
// filename also must be changed
public interface IEmployee
{
    // fields are not allowed
    // constructors are not allowed
    // all methods are abstract and public by default
    string GetHealthInsuranceAmount();

    // auto-properties
    // properties are public by default
    // dont need set explicitly
    int Id { get; set; }

    string Name { get; set; }

    string Location { get; set; }

}