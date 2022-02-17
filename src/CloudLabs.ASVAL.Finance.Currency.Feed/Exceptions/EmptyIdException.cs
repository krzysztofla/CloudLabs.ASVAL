namespace CloudLabs.ASVAL.Finance.Currency.Feed.Exceptions;

public class EmptyIdException : CurrencyExceptions
{
    public EmptyIdException(string code, string message) : base(code, message)
    {
       
    }
}