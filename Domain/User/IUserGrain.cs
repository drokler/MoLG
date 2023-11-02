using Dto.User;

namespace Domain.User;

public interface IUserGrain: IGrainWithStringKey
{
    Task<UserDto> GetDto();
    Task<bool> CheckCredentials(string pass);
    Task<List<string>> GetRoles();
    Task AddRoles(List<string> roles);
    Task RemoveRoles(List<string> roles);
    Task SetAuthData(string passHash);
}