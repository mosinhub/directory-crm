using DirectoryService.Domain.Common.ValueObjects;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions;

public sealed class Position
{
    private Position(Name name)
    {
        Id = PositionId.New();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public PositionId Id { get; private set; }
    public Name Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Position Create(Name name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return new Position(name);
    }
}
