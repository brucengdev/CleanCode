
//putting variables into a class gives it a context
//now you know that the city, district, country variables are all part of
//an address context, even the compiler knows this
//this makes it much easier for programmer to know what the variables and methods are about
//since they are all inside a context, also this simplifies the names of the variables
//and methods.
class Address
{
    public string Country { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string HouseNo { get; set; }

    public string MakeMessage()
    {
        return $"The address is {HouseNo}, {District} district, {City}, {Country}.";
    }
}

public class Program
{
    //an example of variables with no meaningful context
    //the context needs to be inferred from the method name and the implementation
    private static void PrintAddress(string country, string city, string district, string houseNo)
    {
        Console.WriteLine("The address is {0}, {1} district, {2}, {3}.", houseNo, district, city, country);
    }
    
    public static void Main(string[] args)
    {
        //using the arguments without meaningful context
        PrintAddress("Vietnam", "Hanoi", "Dong Da", "165");
        
        //using the arguments with meaningful context
        var address = new Address { City = "Hanoi", Country = "Vietnam", District = "Dong Da", HouseNo = "165" };
        Console.WriteLine(address.MakeMessage());
    }
}