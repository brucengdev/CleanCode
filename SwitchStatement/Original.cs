namespace OriginalCode
{
    public enum EmployeeType
    {
        Commissioned,
        Hourly,
        Salaried,
    }

    public class Employee
    {
        public EmployeeType Type { get; set; }
    }

    public class Original
    {
        //this is an example of problematic code with switch statement
        //This violates SRP (single responsibility principle): it's doing more than one thing
        //This violates the OCP (open closed principle): adding new employee type requires changing this code
        public static double CalculatePay(Employee e)
        {
            switch (e.Type)
            {
                case EmployeeType.Commissioned:
                    return calculateCommissionedPay(e);
                case EmployeeType.Hourly:
                    return calculateHourlyPay(e);
                case EmployeeType.Salaried:
                    return calculateSalariedPay(e);
                default:
                    throw new Exception("Invalid employee type");
            }
        }

        private static double calculateHourlyPay(Employee employee)
        {
            return 1;
        }

        private static double calculateSalariedPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        private static double calculateCommissionedPay(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}