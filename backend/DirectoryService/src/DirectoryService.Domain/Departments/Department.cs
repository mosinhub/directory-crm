using DirectoryService.Domain.Common.ValueObjects;
using DirectoryService.Domain.Departments.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    private Department(
        Name name,
        DepartmentSlug slug,
        DepartmentPath path,
        DepartmentId? parentId)
    {
        Id = DepartmentId.New();
        Name = name;
        Slug = slug;
        Path = path;
        ParentId = parentId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public DepartmentId Id { get; private set; }
    public Name Name { get; private set; }
    public DepartmentSlug Slug { get; private set; }
    public DepartmentPath Path { get; private set; }
    public DepartmentId? ParentId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Department Create(
        Name name,
        DepartmentSlug slug,
        Department? parentDepartment)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(slug);

        if (parentDepartment is null)
            return new Department(name, slug, DepartmentPath.Create(slug, null), null);

        return new Department(
            name,
            slug,
            DepartmentPath.Create(slug, parentDepartment.Path),
            parentDepartment.Id);
    }
}
