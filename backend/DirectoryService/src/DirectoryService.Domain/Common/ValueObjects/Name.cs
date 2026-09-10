namespace DirectoryService.Domain.Common.ValueObjects;

public sealed record Name
{
    public const int MaxLength = 100;

    private Name(string name) => Value = name;

    public string Value { get; }

    public static Name Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        string normalizedName = name.Trim();

        if (normalizedName.Any(char.IsControl))
            throw new ArgumentException("Name must not contain control characters.", nameof(name));

        if (normalizedName.Length > MaxLength)
            throw new ArgumentException($"Name must not exceed {MaxLength} characters.", nameof(name));

        return new Name(normalizedName);
    }
}
