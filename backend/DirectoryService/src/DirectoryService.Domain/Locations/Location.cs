using DirectoryService.Domain.Common.ValueObjects;
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.Locations;

public sealed class Location
{
    private Location(Name name, Address address)
    {
        Id = LocationId.New();
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public LocationId Id { get; private set; }
    public Name Name { get; private set; }
    public Address Address { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Location Create(Name name, Address address)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(address);

        return new Location(name, address);
    }
}
