public class Number
{
    private int value;

    public void SetValue(int value)
    {
        this.value = value;
    }

    public double GetValue()
    {
        return value;
    }

    public bool IsZero()
    {
        return value == 0;
    }

    public bool IsPositive()
    {
        return value > 0;
    }

    public bool IsNegative()
    {
        return value < 0;
    }

    public bool IsOdd()
    {
        return value % 2 != 0;
    }

    public bool IsEven()
    {
        return value % 2 == 0;
    }

    public bool IsPrime()
    {
        if (value <= 1) return false;
        for (int i = 2; i < value; i++)
        {
            if (value % i == 0) return false;
        }
        return true;
          
       
    }

    public int GetCountOfDigits()
    {
        return value.ToString().Length;
    }

    public int GetSumOfDigits()
    {
        int sum = 0;
        int n = value;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
       
    }

   public int GetReverse()
    {
        int n = value, reverse = 0;
       while (n != 0)
        {
            reverse = reverse * 10;
            reverse = reverse + n % 10;
            n = n / 10;
        }
        return +reverse;
    }


    // public string GetFibonacci()

    // public bool isPalindrome()

}