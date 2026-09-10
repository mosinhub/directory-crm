namespace DirectoryService.Domain.Positions.ValueObjects;

public sealed record PositionId
{
    private PositionId(Guid positionId) => Value = positionId;

    public Guid Value { get; }

    public static PositionId New() => Create(Guid.CreateVersion7());

    public static PositionId Create(Guid positionId)
    {
        if (positionId == Guid.Empty)
            throw new ArgumentException("Position ID must not be empty.", nameof(positionId));

        return new PositionId(positionId);
    }
}
