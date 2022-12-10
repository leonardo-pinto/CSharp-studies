public struct Category
{
    private int _categoryId;
    private int _codeNumber;

    public int CategoryId {
        get
        {
            return _categoryId;
        }    
        set
        {
            _categoryId = value;
        } 
    }
    public int CodeNumber {
    
        get
        {
            return _codeNumber;
        }
        set
        {
            _codeNumber = value;
        }
    }

    // parametrized constructor
    public Category(int categoryId, int codeNumber)
    {
        _categoryId = categoryId;
        _codeNumber = codeNumber;
    }
}