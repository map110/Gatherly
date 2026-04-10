using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.DomainEvents;

public sealed record class InvitationAcceptedDomainEvent(Guid InvitationId, Guid GatheringId) : IDomainEvent
{
}