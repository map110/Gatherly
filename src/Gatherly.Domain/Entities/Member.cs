using Gatherly.Domain.DomainEvents;
using Gatherly.Domain.Primitives;
using Gatherly.Domain.ValueObjects;

namespace Gatherly.Domain.Entities;

public class Member : AggregateRoot
{
    private Member(Guid id, FirstName firstName, LastName lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private Member()
    {
    }

    public FirstName FirstName { get; set; }

    public LastName LastName { get; set; }

    public Email Email { get; set; }

    public static Member Create(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email,
        bool isEmailUnique)
    {
        if (isEmailUnique)
        {
            return null;
        }

        var member = new Member(
            id,
            firstName,
            lastName,
            email);
        member.RaiseDomainEvent(new MemberRegisteredDomainEvent(member.Id));
        return member;
    }
}