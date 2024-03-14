/**
 * Sometimes clarifying comments are useful
 * a.CompareTo(b) == -1 can be understood by programmers but not great.
 * adding a comment to clarify that the condition means a < b makes it
 * instantly clear to readers and remove a step of reasoning.
 *
 * Of course, it is better to wrap it in a method that clearly says the meaning
 * Like a.LessThan(b)
 */

public static class StringExtensions
{
    public static bool IsLessThan(this string a, string b)
    {
        return a.CompareTo(b) == -1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string a = "Ted Mosby";
        string b = "Lily Aldrin";

        //a < b
        if (a.CompareTo(b) == -1)
        {
            Console.WriteLine("Great");
        }
        else
        {
            Console.WriteLine("Not great");
        }

        if (a.IsLessThan(b))//much better, no need for comment
        {
            Console.WriteLine("Great");
        }
        else
        {
            Console.WriteLine("Not great");
        }
    }
}

