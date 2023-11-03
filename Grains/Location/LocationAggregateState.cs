namespace Grains.Location;

public class LocationAggregateState
{
    public List<LocationKey> Keys { get; set; } = new();
}

public class LocationKey
{
    public ushort MinZoom { get; set; }
    public ushort MaxZoom { get; set; }
    public short Lat { get; set; }
    public short Lon { get; set; }
    public required string Id { get; set; }
}