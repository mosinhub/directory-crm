namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record Address
{
    public const int MaxRegionLength = 100;
    public const int MaxLocalityLength = 100;
    public const int MaxDistrictLength = 100;
    public const int MaxAddressLine1Length = 200;
    public const int MaxAddressLine2Length = 200;

    private Address(
        CountryCode countryCode,
        string? region,
        string locality,
        string? district,
        string addressLine1,
        string? addressLine2,
        PostalCode? postalCode)
    {
        CountryCode = countryCode;
        Region = region;
        Locality = locality;
        District = district;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        PostalCode = postalCode;
    }

    public CountryCode CountryCode { get; }
    public string? Region { get; }
    public string Locality { get; }
    public string? District { get; }
    public string AddressLine1 { get; }
    public string? AddressLine2 { get; }
    public PostalCode? PostalCode { get; }

    public static Address Create(
        string countryCode,
        string? region,
        string locality,
        string? district,
        string addressLine1,
        string? addressLine2,
        string? postalCode)
    {
        var countryCodeValue = CountryCode.Create(countryCode);
        var normalizedRegion = NormalizeOptional(
            region,
            "Region",
            nameof(region),
            MaxRegionLength);
        var normalizedLocality = NormalizeRequired(
            locality,
            "Locality",
            nameof(locality),
            MaxLocalityLength);
        var normalizedDistrict = NormalizeOptional(
            district,
            "District",
            nameof(district),
            MaxDistrictLength);
        var normalizedAddressLine1 = NormalizeRequired(
            addressLine1,
            "Address line 1",
            nameof(addressLine1),
            MaxAddressLine1Length);
        var normalizedAddressLine2 = NormalizeOptional(
            addressLine2,
            "Address line 2",
            nameof(addressLine2),
            MaxAddressLine2Length);
        var postalCodeValue = string.IsNullOrWhiteSpace(postalCode)
            ? null
            : PostalCode.Create(postalCode);

        return new Address(
            countryCodeValue,
            normalizedRegion,
            normalizedLocality,
            normalizedDistrict,
            normalizedAddressLine1,
            normalizedAddressLine2,
            postalCodeValue);
    }

    private static string? NormalizeOptional(
        string? value,
        string fieldName,
        string parameterName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var normalizedValue = value.Trim();

        if (normalizedValue.Any(char.IsControl))
            throw new ArgumentException(
                $"{fieldName} must not contain control characters.",
                parameterName);

        if (normalizedValue.Length > maxLength)
            throw new ArgumentException(
                $"{fieldName} must not exceed {maxLength} characters.",
                parameterName);

        return normalizedValue;
    }

    private static string NormalizeRequired(
        string value,
        string fieldName,
        string parameterName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} is required.", parameterName);

        var normalizedValue = value.Trim();

        if (normalizedValue.Any(char.IsControl))
            throw new ArgumentException(
                $"{fieldName} must not contain control characters.",
                parameterName);

        if (normalizedValue.Length > maxLength)
            throw new ArgumentException(
                $"{fieldName} must not exceed {maxLength} characters.",
                parameterName);

        return normalizedValue;
    }
}
