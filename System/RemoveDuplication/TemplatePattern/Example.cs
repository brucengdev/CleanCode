namespace TemplatePattern
{
    /**
     * The VacationPolicy class is a template that 
     * contains all the common operations.
     * It provides an abstract method so that the template can be used
     * to implement different policies.
     * The common operations are not duplicated this way.
     **/
    public abstract class VacationPolicy
    {
        public void AccrueVacation()
        {
            CalculateBaseVacationHours();
            AlterForLegalMinimum();
            ApplyToPayroll();
        }

        public void CalculateBaseVacationHours() { }
        public abstract void AlterForLegalMinimum();

        public void ApplyToPayroll() { }
    }

    public class USVacationPolicy : VacationPolicy
    {
        public override void AlterForLegalMinimum()
        {
            //specifics to calculate vacation in US
        }
    }

    public class EUVacationPolicy: VacationPolicy
    {
        public override void AlterForLegalMinimum()
        {
            //specifics to calculate vacation in EU
        }
    }
}
