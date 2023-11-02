namespace Dto.Tips;

public class TipDto
{
    public required string Id { get; set; }
    public required string Body { get; set; }
    public string? TipStatement { get; set; }
}