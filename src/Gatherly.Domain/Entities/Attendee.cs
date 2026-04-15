namespace Gatherly.Domain.Entities;

public class Attendee
{
    internal Attendee(Invitation invitation)
    {
        GatheringId = invitation.GatheringId;
        MemberId = invitation.MemberId;
        CreatedOnUtc = DateTime.UtcNow;
    }

    private Attendee()
    {
    }

    public Guid GatheringId { get; set; }

    public Guid MemberId { get; set; }

    public DateTime CreatedOnUtc { get; set; }
}