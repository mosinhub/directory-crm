namespace DirectoryService.Domain.Departments.ValueObjects;

public sealed record DepartmentPositionId
{
    private DepartmentPositionId(Guid departmentPositionId) => Value = departmentPositionId;

    public Guid Value { get; }

    public static DepartmentPositionId New() => Create(Guid.CreateVersion7());

    public static DepartmentPositionId Create(Guid departmentPositionId)
    {
        if (departmentPositionId == Guid.Empty)
            throw new ArgumentException(
                "Department position ID must not be empty.",
                nameof(departmentPositionId));

        return new DepartmentPositionId(departmentPositionId);
    }
}
