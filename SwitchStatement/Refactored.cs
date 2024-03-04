using OriginalCode;

/**
 * Example of refactored switch statement.
 * The switch statement is best buried somewhere in a factory class.
 * And it is only used to create objects with polymorphism, to keep most of the logic out.
 * So that the switch statement is as trivial as possible.
 */

namespace Refactored
{
    public class EmployeeRecord
    {
        public EmployeeType Type { get; set; }
    }
    public abstract class Employee
    {
        public EmployeeType Type { get; set; }

        public Employee(EmployeeType type)
        {
            Type = type;
        }

        public abstract double CalculatePay();
    }

    public class CommissionedEmployee : Employee
    {
        public CommissionedEmployee(EmployeeRecord r) : base(EmployeeType.Commissioned) { }
        public override double CalculatePay()
        {
            throw new NotImplementedException();
        }
    }
    
    public class HourlyEmployee : Employee
    {
        public HourlyEmployee(EmployeeRecord r) : base(EmployeeType.Hourly) { }
        public override double CalculatePay()
        {
            throw new NotImplementedException();
        }
    }
    
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(EmployeeRecord r) : base(EmployeeType.Salaried) { }
        public override double CalculatePay()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeFactory
    {
        Employee CreateEmployee(EmployeeRecord r);
    }

    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee CreateEmployee(EmployeeRecord r)
        {
            switch (r.Type)
            {
                case EmployeeType.Commissioned:
                    return new CommissionedEmployee(r);
                case EmployeeType.Hourly:
                    return new HourlyEmployee(r);
                case EmployeeType.Salaried:
                    return new SalariedEmployee(r);
                default:
                    throw new Exception("Invalid employee type");
            }
        }
    }
}