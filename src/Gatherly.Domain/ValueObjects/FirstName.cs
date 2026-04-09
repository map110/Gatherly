using Gatherly.Domain.Primitives;
using Gatherly.Domain.Shared;

namespace Gatherly.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FirstName>(new Error("FirstName.Empty", "FirstName is empty."));
        }

        if (firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(new Error("FirstName.TooLong", "FirstName is too long."));
        }

        return new FirstName(firstName);
    }

    public override IEnumerable<Object> GetAtomicValues()
    {
        yield return Value;
    }
}