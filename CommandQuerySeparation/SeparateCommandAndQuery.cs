namespace CommandQuerySeparation;

public class Product
{
    private string Name { get; set; }
    
    /// <summary>
    /// An example of mixing command and query
    /// What does this do? Does it work?
    /// </summary>
    /// <param name="attribute"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Set(string attribute, string value)
    {
        if (attribute == "Name")
        {
            Name = value;
            return true;
        }

        return false;
    }
    
    //example of separating Command and Query
    public void SetAttribute(string attributeName, string value)
    {
        if (attributeName == "Name")
        {
            Name = value;
        }
    }

    public bool AttributeExists(string attributeName)
    {
        if (attributeName == "Name")
        {
            return true; 
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var product = new Product();
        //this statement is strange
        //does it mean has Name been set to soap?
        //does it mean to check if Name was set to soap successfully?
        //It does something, but it also returns a value.
        if (product.Set("Name", "soap"))
        {
            Console.WriteLine("Attribute Name was set to soap");
        }
        else
        {
            Console.WriteLine("Could not set value for attribute Name");
        }
        
        //example of separating commands and queries
        //it is very clear what each function call does, there is no mistaking it.
        if (!product.AttributeExists("Name"))
        {
            Console.WriteLine("Attribute Name does not exist");
            return;
        }
        product.SetAttribute("Name", "soap");
        Console.WriteLine("Attribute Name was set to soap");
    }
}