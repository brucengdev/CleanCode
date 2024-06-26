
internal class PriceCalculatorWithTemporalCoupling
{
    private float eurRate = 0;
    public void UpdateCurrencyRates(float eurRate) { this.eurRate = eurRate; }

    public decimal CalculatePrice(int[] itemIDs) {
        if(eurRate == 0) throw new Exception("Must add rates");
        return (decimal)(itemIDs.Length * eurRate);
    }
}

internal class Rate
{
    private float _rate;
    public Rate(float rate) {  _rate = rate; }

    public float Value {  get {  return _rate; } }
}

internal class PriceCalculatorWithExplicitCoupling
{
    public Rate UpdateCurrencyRate(float rate) => new Rate(rate);
    public decimal CalculatePrice(int[] itemIDs, Rate eurRate)
    {
        return (decimal)(itemIDs.Length * eurRate.Value);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Example of temporal coupling.");

        //temporal coupling is when functions depend on each other
        //but there is no logical enforcement and they can be called in wrong order.
        var priceCal1 = new PriceCalculatorWithTemporalCoupling();
        try { 
        priceCal1.CalculatePrice(new[] {1,2,3});//throws exception
        }catch { }

        //correct usage when there is temporal coupling
        priceCal1.UpdateCurrencyRates(2);
        priceCal1.CalculatePrice(new[] {1,2,3});

        //eliminate temporal coupling
        //by making sure the result of one function is the input
        //of the other, so there is no way to call them out of order.
        var priceCal2 = new PriceCalculatorWithExplicitCoupling();
        var rate = priceCal2.UpdateCurrencyRate(2);
        priceCal2.CalculatePrice(new[] { 1, 2, 3 }, rate);
    }
}