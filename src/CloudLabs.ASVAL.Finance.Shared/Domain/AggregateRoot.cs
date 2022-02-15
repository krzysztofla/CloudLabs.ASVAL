namespace CloudLabs.ASVAL.Finance.Shared.Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }

    public int Version { get; protected set; }

    bool _vesrsionIncremented = false;

    public IEnumerable<IDomainEvent> Events => _events;


    private readonly List<IDomainEvent> _events = new();

    public void ClearEvents() => _events.Clear();

    protected void AddEvent(IDomainEvent @event)
    {
        if(!_events.Any() && !_vesrsionIncremented)
        {
            Version++;
            _vesrsionIncremented = true;

        }

        _events.Add(@event);
    }


    protected void IncrementVersion()
    {
        if (_vesrsionIncremented)
        {
            return;
        }

        Version++;
        _vesrsionIncremented = true;
    }


}