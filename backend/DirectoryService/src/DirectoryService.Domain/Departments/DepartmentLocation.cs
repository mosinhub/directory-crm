using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.Departments;

public sealed class DepartmentLocation
{
    private DepartmentLocation(
        DepartmentId departmentId,
        LocationId locationId,
        bool isPrimary)
    {
        Id = DepartmentLocationId.New();
        DepartmentId = departmentId;
        LocationId = locationId;
        IsPrimary = isPrimary;
    }

    public DepartmentLocationId Id { get; private set; }
    public DepartmentId DepartmentId { get; private set; }
    public LocationId LocationId { get; private set; }
    public bool IsPrimary { get; private set; }

    public static DepartmentLocation Create(
        DepartmentId departmentId,
        LocationId locationId,
        bool isPrimary)
    {
        ArgumentNullException.ThrowIfNull(departmentId);
        ArgumentNullException.ThrowIfNull(locationId);

        return new DepartmentLocation(departmentId, locationId, isPrimary);
    }
}
