namespace Gatherly.Presentation.Contracts.Members;

public sealed record RegisterMemberRequest(
    string FirstName,
    string LastName,
    string Email);