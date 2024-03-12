namespace ExplainYourselfInCode;

public class Employee
{
    public bool IsHourly { get; set; }
    public int Age { get; set; }

    public bool IsEligibleForFullBenefits() =>
        IsHourly && Age > 65;
}

/**
 * In the first example, the comment is necessary to explain what the if condition is checking
 * But in the second example, you can see that the comment is not necessary at all, you can
 * perfectly rewrite code to make your intention clear, without having to maintain comments.
 */

public class Examples
{
    public void ExampleWithComment(Employee emp)
    {
        //Check to see if the employee is eligible for full benefits
        if (emp.IsHourly && emp.Age > 65)
        {
            //...
        }
    }

    public void RefactoredExample(Employee emp)
    {
        if (emp.IsEligibleForFullBenefits())
        {
            //...
        }
    }
}