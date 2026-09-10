namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record LocationId
{
    private LocationId(Guid locationId) => Value = locationId;

    public Guid Value { get; }

    public static LocationId New() => Create(Guid.CreateVersion7());

    public static LocationId Create(Guid locationId)
    {
        if (locationId == Guid.Empty)
            throw new ArgumentException("Location ID must not be empty.", nameof(locationId));

        return new LocationId(locationId);
    }
}
