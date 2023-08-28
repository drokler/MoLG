namespace Domain.User;

public interface IUserGrain: IGrainWithStringKey
{
    Task<bool> CheckCredentials(string pass);
    Task<List<string>> GetRoles();
}