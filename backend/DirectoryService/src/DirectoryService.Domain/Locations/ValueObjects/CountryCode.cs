namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record CountryCode
{
    public const int Length = 2;

    private CountryCode(string countryCode) => Value = countryCode;

    public string Value { get; }

    public static CountryCode Create(string countryCode)
    {
        if (string.IsNullOrWhiteSpace(countryCode))
            throw new ArgumentException(
                "Country code is required.",
                nameof(countryCode));

        string normalizedCode = countryCode.Trim().ToUpperInvariant();

        if (normalizedCode.Length != Length || !ContainsOnlyLatinLetters(normalizedCode))
            throw new ArgumentException(
                $"Country code must consist of exactly {Length} Latin letters.",
                nameof(countryCode));

        return new CountryCode(normalizedCode);
    }

    private static bool ContainsOnlyLatinLetters(string value) =>
        value.All(char.IsAsciiLetter);
}
