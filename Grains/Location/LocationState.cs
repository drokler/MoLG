namespace Grains.Location;

public class LocationState
{
    public required string Name { get; set; } = "defaultLocation";
    public required string Description { get; set; } = "Без описания";
    public double Lat { get; set; }
    public double Lon { get; set; }
    public ushort MinZoom { get; set; }
    public ushort MaxZoom { get; set; }
    public bool DefaultKnown { get; set; }
}