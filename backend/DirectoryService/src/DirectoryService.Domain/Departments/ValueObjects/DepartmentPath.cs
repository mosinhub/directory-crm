namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentPath
{
    public const int MaxLength = 512;

    private DepartmentPath(string value) => Value = value;

    public string Value { get; }

    public static DepartmentPath Create(DepartmentSlug slug, DepartmentPath? parentPath)
    {
        ArgumentNullException.ThrowIfNull(slug);

        var path = parentPath is null
            ? slug.Value
            : $"{parentPath.Value}/{slug.Value}";

        if (path.Length > MaxLength)
            throw new ArgumentException(
                $"Department path must not exceed {MaxLength} characters.",
                nameof(slug));

        return new DepartmentPath(path);
    }
}
