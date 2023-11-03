using Dto.Common;

namespace Dto.Npc;

public class NpcDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public PointDto? Location { get; set; }
}