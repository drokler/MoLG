using Domain.User;
using Dto.User;
using Orleans.Providers;

namespace Grains.User;

[StorageProvider]
public class UserGrain: Grain<UserState>, IUserGrain
{
    public Task<UserDto> GetDto()
    {
        return Task.FromResult(new UserDto()
        {
            Login = this.GetPrimaryKeyString(),
            Name = State.Name,
            Roles = State.Roles
        });
    }
    
    public Task<bool> CheckCredentials(string pass)
    {
        if (State.PasswordHash == null)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(string.CompareOrdinal(pass, State.PasswordHash) == 0);
    }

    public Task<List<string>> GetRoles()
    {
        return Task.FromResult(State.Roles);
    }

    public async Task AddRoles(List<string> roles)
    {
        State.Roles = State.Roles.Union(roles).Distinct().ToList();
        await WriteStateAsync();
    }

    public async Task RemoveRoles(List<string> roles)
    {
        State.Roles = State.Roles.Except(roles).ToList();
        await WriteStateAsync();
    }

    public async Task SetAuthData(string passHash)
    {
        State.PasswordHash = passHash;
        await WriteStateAsync();
    }
}