namespace CloudLabs.ASVAL.Finance.Currency.Exceptions;

public class EmptyIdException : CurrencyExceptions
{
    public EmptyIdException(string code, string message) : base(code, message)
    {
       
    }
}