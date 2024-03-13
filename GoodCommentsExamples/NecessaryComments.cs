using System.Text.RegularExpressions;

namespace GoodCommentsExamples;

/**
 * In this example, readers won't know what kind of date time string that TimeMatcher matches
 * Readers would have to read the regex and try to figure out what it is doing.
 *
 * So the comment is helpful.
 */

public class NecessaryComments
{
    //The pattern matches kk:mm:ss EEE, MMM dd, yyyy
    public static Regex TimeMatcher = new Regex(@"\d*:\d*:\d* \w*, \w* \d*, \d*", RegexOptions.Singleline);

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a date in format kk:mm:ss EEE, MMM dd, yyyy");
        string input = Console.ReadLine();
        var matched = TimeMatcher.Match(input);
        Console.WriteLine(matched.Success? "Valid date time": "Invalid date time");
    }
}