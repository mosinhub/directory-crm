using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class DepartmentPosition
{
    private DepartmentPosition(DepartmentId departmentId, PositionId positionId)
    {
        Id = DepartmentPositionId.New();
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public DepartmentPositionId Id { get; private set; }
    public DepartmentId DepartmentId { get; private set; }
    public PositionId PositionId { get; private set; }

    public static DepartmentPosition Create(
        DepartmentId departmentId,
        PositionId positionId)
    {
        ArgumentNullException.ThrowIfNull(departmentId);
        ArgumentNullException.ThrowIfNull(positionId);

        return new DepartmentPosition(departmentId, positionId);
    }
}
