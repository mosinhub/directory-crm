namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentId
{
    private DepartmentId(Guid departmentId) => Value = departmentId;

    public Guid Value { get; }

    public static DepartmentId New() => Create(Guid.CreateVersion7());

    public static DepartmentId Create(Guid departmentId)
    {
        if (departmentId == Guid.Empty)
            throw new ArgumentException("Department ID must not be empty.", nameof(departmentId));

        return new DepartmentId(departmentId);
    }
}
