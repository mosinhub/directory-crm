namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record PostalCode
{
    public const int MaxLength = 10;

    private PostalCode(string postalCode) => Value = postalCode;

    public string Value { get; }

    public static PostalCode Create(string postalCode)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code is required.", nameof(postalCode));

        string normalizedPostalCode = postalCode.Trim().ToUpperInvariant();

        if (normalizedPostalCode.Any(char.IsControl))
            throw new ArgumentException(
                "Postal code must not contain control characters.",
                nameof(postalCode));

        if (normalizedPostalCode.Length > MaxLength)
            throw new ArgumentException(
                $"Postal code must not exceed {MaxLength} characters.",
                nameof(postalCode));

        return new PostalCode(normalizedPostalCode);
    }
}
