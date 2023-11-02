namespace Grains.User;

public class UserAggregationState
{
    public bool IsSetup { get; set; }
    public List<string> Logins { get; set; } = new();
}