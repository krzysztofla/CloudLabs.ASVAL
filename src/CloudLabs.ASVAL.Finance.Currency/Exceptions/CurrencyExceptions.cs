namespace CloudLabs.ASVAL.Finance.Currency.Exceptions;

public abstract class CurrencyExceptions : Exception
{
    public string Code { get; }

    protected CurrencyExceptions(string code, string message) : base(message)
    {
        Code = code;
    }
}