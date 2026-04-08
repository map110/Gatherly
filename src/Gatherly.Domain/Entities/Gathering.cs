namespace Gatherly.Domain.Entities;

public class Gathering
{
    private Gathering(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location)
    {
        Id = id;
        Creator = creator;
        Type = type;
        ScheduledAtUtc = scheduledAtUtc;
        Name = name;
        Location = location;
    }

    public Guid Id { get; private set; }

    public Member Creator { get; private set; }

    public GatheringType Type { get; private set; }

    public string Name { get; private set; }

    public DateTime ScheduledAtUtc { get; private set; }

    public string? Location { get; private set; }

    public int? MaximumNumberOfAttendees { get; private set; }

    public DateTime? InvitationsExpireAtUtc { get; private set; }

    public int NumberOfAttendees { get; private set; }

    public static Gathering Create(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location,
        int? maximumNumberOfAttendees,
        int? invitationsValidBeforeInHours)
    {
        // Create gathering
        var gathering = new Gathering(
            Guid.NewGuid(),
            creator,
            type,
            scheduledAtUtc,
            name,
            location);

        // Calculate gathering type details
        switch (gathering.Type)
        {
            case GatheringType.WithFixedNumberOfAttendees:
                if (maximumNumberOfAttendees is null)
                {
                    throw new Exception(
                        $"{nameof(maximumNumberOfAttendees)} can't be null.");
                }

                gathering.MaximumNumberOfAttendees = maximumNumberOfAttendees;
                break;
            case GatheringType.WithExpirationForInvitations:
                if (invitationsValidBeforeInHours is null)
                {
                    throw new Exception(
                        $"{nameof(invitationsValidBeforeInHours)} can't be null.");
                }

                gathering.InvitationsExpireAtUtc =
                    gathering.ScheduledAtUtc.AddHours(-invitationsValidBeforeInHours.Value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(GatheringType));
        }

        return gathering;
    }
}