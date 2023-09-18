using Domain.User;
using Orleans.Providers;

namespace Grains.User;

[StorageProvider]
public class UserGrain: Grain<UserState>, IUserGrain
{
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
}