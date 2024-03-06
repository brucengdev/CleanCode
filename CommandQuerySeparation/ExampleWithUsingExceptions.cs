namespace CommandQuerySeparation.ExceptionsVsErrorCodes.Refactored;

public class DivisorTooLargeException: Exception {}

public class Number
{
    private int _value;
    public int Value
    {
        get { return _value; }
    }

    public Number(int value)
    {
        this._value = value;
    }

    //use exceptions instead of returning error codes
    //so that function Divide is doing one thing only
    public void Divide(int divisor)
    {
        if (divisor > _value) throw new DivisorTooLargeException();
        _value /= divisor;
    }

    public void Add(int n)
    {
        _value += n;
    }
}

public class Program
{
    //by not returning error codes in function Divide
    //callers don't have to handle error codes and the logic becomes straight forward.
    //all error handling is consolidated and moved outside the happy code path
    public static void Calculate(int a, int b)
    {
        //the happy code path in the try block is simple
        //straight forward and easy to understand
        try
        {
            var number = new Number(a);
            number.Divide(b);
            number.Add(b);
        }//all error handling is consolidated in catch blocks
        catch (DivideByZeroException)
        {
            Console.WriteLine("Divisor must not be Zero");
        }
        catch (DivisorTooLargeException)
        {
            Console.WriteLine("Divisor is too large");
        }
    }
    public static void Main(string[] args)
    {
        Calculate(25, 0);
    }
}