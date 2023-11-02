namespace Grains.Npc;

public class NpcStatus
{
    public DateTimeOffset TimeAfterStart { get; set; }
    public required string Status { get; set; } = "DefaultStatus";
}