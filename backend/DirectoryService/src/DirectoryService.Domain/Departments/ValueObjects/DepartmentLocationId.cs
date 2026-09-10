namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentLocationId
{
    private DepartmentLocationId(Guid departmentLocationId) => Value = departmentLocationId;

    public Guid Value { get; }

    public static DepartmentLocationId New() => Create(Guid.CreateVersion7());

    public static DepartmentLocationId Create(Guid departmentLocationId)
    {
        if (departmentLocationId == Guid.Empty)
            throw new ArgumentException(
                "Department location ID must not be empty.",
                nameof(departmentLocationId));

        return new DepartmentLocationId(departmentLocationId);
    }
}
