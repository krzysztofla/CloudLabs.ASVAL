namespace CloudLabs.ASVAL.Fnance.Price.Feed.ValueObjects;

public class Pricing
{
    public Int32 Value { get; set; }
    public string Symbol { get; set; } = null;
    public Int64 Datetime { get; set; }
}