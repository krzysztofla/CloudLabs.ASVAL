using CloudLabs.ASVAL.Finance.Currency.Feed.Exceptions;

namespace CloudLabs.ASVAL.Finance.Currency.Feed.ValueObjects;

public record CoinId
{
    public Guid Value { get; }

    public CoinId(Guid id)
    {
        if(id == Guid.Empty)
        {
            throw new EmptyIdException(ExceptionCodes.IncorrectCoinId, ExceptionMessages.EmptyIdValue);
        }
        Value = id;
    }

    public static implicit operator Guid(CoinId id) => id.Value;

    public static implicit operator CoinId(Guid id) => new(id);
}