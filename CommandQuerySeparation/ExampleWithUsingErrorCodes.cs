namespace CommandQuerySeparation.ExceptionsVsErrorCodes.Original;

public enum DivisionErrors
{
    NoError,
    DivideByZero,
    DivisorTooLarge
}

public class Number
{
    private int _value { get; set; }
    public int Value
    {
        get { return _value; }
    }
    public Number(int value)
    {
        this._value = value; 
    }
    //Returning error codes means we are mixing command and query into one function
    public DivisionErrors Divide(int divisor)
    {
        if (divisor == 0)
        {
            return DivisionErrors.DivideByZero;
        }

        if (divisor > _value)
        {
            return DivisionErrors.DivisorTooLarge;
        }

        _value /= divisor;

        return DivisionErrors.NoError;
    }

    public void Add(int n)
    {
        _value += n;
    }
    
}

public class Program
{
    //Using error codes will force the caller to handle the error codes
    //and mixes error handling with the logic of the code, making it harder to read
    //and understand, more prone to errors during maintenance.
    //Consider using Exceptions and do not return error codes at all.
    public static void Calculate(int a, int b)
    {
        var number = new Number(a);
        var status = number.Divide(b);
        if (status == DivisionErrors.DivideByZero)
        {
            Console.WriteLine("Cannot divide by Zero");
            return;
        } else if (status == DivisionErrors.DivisorTooLarge)
        {
            Console.WriteLine("Divisor is too large");
            return;
        }
        number.Add(b);
        Console.WriteLine("Result: {0}", number.Value);
    }
    public static void Main(string[] args)
    {
        Calculate(12, 8);
    }
}