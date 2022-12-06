public class Car
{
    // private field
    private string[] _brands = new string[] { "BMW", "Audi", "Toyota" };

    // public indexer
    public string this[int index]
    {
        set
        {
            this._brands[index] = value;

        }
        get
        { 
            return this._brands[index];
        }
    }


}