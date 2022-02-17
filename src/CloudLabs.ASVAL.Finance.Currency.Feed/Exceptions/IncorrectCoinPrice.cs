namespace CloudLabs.ASVAL.Finance.Currency.Feed.Exceptions;

public class IncorrectCoinPrice : CurrencyExceptions
{
    public IncorrectCoinPrice(string code, string message) : base(code, message)
    {
    }
}