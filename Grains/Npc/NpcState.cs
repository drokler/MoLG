namespace Grains.Npc;

public class NpcState
{
    public required string Name { get; set; } = "DefaultName";
    public string? Description { get; set; }
    public List<NpcLocation> DefaultLocations { get; set; } = new();
    public NpcLocation? OverrideLocation { get; set; } = null;
    public List<NpcStatus> DefaultStatuses { get; set; } = new();
    public NpcStatus? OverrideStatus { get; set; } = null;
}