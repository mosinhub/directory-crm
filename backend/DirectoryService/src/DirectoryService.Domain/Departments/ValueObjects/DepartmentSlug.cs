using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed partial record DepartmentSlug
{
    public const int MinLength = 2;
    public const int MaxLength = 64;

    private DepartmentSlug(string slug) => Value = slug;

    public string Value { get; }

    [SuppressMessage(
        "Globalization",
        "CA1308:Normalize strings to uppercase",
        Justification = "Slug has a deliberate lowercase canonical representation.")]
    public static DepartmentSlug Create(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            throw new ArgumentException("Department slug is required.", nameof(slug));

        var normalizedSlug = slug.Trim().ToLowerInvariant();

        if (normalizedSlug.Length < MinLength || normalizedSlug.Length > MaxLength)
            throw new ArgumentException(
                $"Department slug must be between {MinLength} and {MaxLength} characters.",
                nameof(slug));

        if (!SlugPattern().IsMatch(normalizedSlug))
            throw new ArgumentException(
                "Department slug may contain only Latin letters, digits, and hyphens, " +
                "and must start and end with a letter or digit.",
                nameof(slug));

        return new DepartmentSlug(normalizedSlug);
    }

    [GeneratedRegex(
        @"^[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
        RegexOptions.CultureInvariant,
        matchTimeoutMilliseconds: 1000)]
    private static partial Regex SlugPattern();
}
