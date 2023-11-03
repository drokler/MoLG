using Dto.Common;

namespace Dto.Location;

public class LocationDto
{
    public required PointDto Point { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ushort MinZoom { get; set; }
    public ushort MaxZoom { get; set; }
    public bool DefaultKnown { get; set; }
}