using CloudLabs.ASVAL.Finance.Currency.Exceptions;

namespace CloudLabs.ASVAL.Finance.Currency.ValueObjects;

internal record Price
{
    private decimal Value { get; }

    public Price(decimal value)
    {
        Value = SetPrice(value);
    }

    private decimal SetPrice(decimal value)
    {
        if (value <= 0)
        {
            throw new IncorrectCoinPrice(ExceptionCodes.IncorrectCoinPriceCode, ExceptionMessages.IncorrectCoinPrice);
        }

        return value;
    }

}