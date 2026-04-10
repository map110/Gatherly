namespace Gatherly.Domain.Primitives;

public class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
    }
}