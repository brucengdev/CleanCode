public interface IBankAccount
{
    void SetBalance(int amount);
    int Withdraw(int amount);
    int Deposit(int amount);
}

public class BankAccount : IBankAccount
{
    private int _balance;
    public int Deposit(int amount)
    {
        _balance += amount;
        return _balance;
    }

    public void SetBalance(int amount)
    {
        _balance = amount;
    }

    public int Withdraw(int amount)
    {
        _balance -= amount;
        return _balance;
    }
}

//using a proxy is away to add new cross cutting concerns like logging
//to an existing class without modifying the class
//extra loggings are added and contained in a module, has no effect to existing
//class
public class BankAccountLogProxy: IBankAccount
{
    private IBankAccount _account;
    public BankAccountLogProxy(IBankAccount account)
    {
        _account = account;
    }

    public int Deposit(int amount)
    {
        var balance = _account.Deposit(amount);
        Console.WriteLine("Deposited {0} into account.", amount);
        return balance;
    }

    public void SetBalance(int amount)
    {
        _account.SetBalance(amount);
        Console.WriteLine("Set account balance to {0}.", amount);
    }

    public int Withdraw(int amount)
    {
        var balance = _account.Withdraw(amount);
        Console.WriteLine("Withdrew {0} from account", amount);
        return balance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var account = new BankAccountLogProxy(new BankAccount());
        account.SetBalance(1000);
        account.Deposit(20);
        account.Withdraw(500);
    }
}