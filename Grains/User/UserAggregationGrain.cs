using Domain.User;
using Dto.User;
using Orleans.Providers;

namespace Grains.User;

[StorageProvider]
public class UserAggregationGrain : Grain<UserAggregationState>, IUserAggregateGrain
{
    public async Task<List<UserDto>> GetUsers()
    {
        var tasks = State.Logins.Select(async id => await GrainFactory.GetGrain<IUserGrain>(id).GetDto()).ToList();
        await Task.WhenAll(tasks);

        return tasks.Select(t => t.Result).ToList();
    }

    public async Task<UserDto> CreateUser(string login, string passHash)
    {
        return await CreateUserWithRole(login, passHash, new List<string>() { "user" });
    }

    public async Task<UserDto> CreateAdmin(string login, string passHash)
    {
        var admin = await CreateUserWithRole(login, passHash, new List<string>() { "admin", "user" });
        State.IsSetup = true;
        await WriteStateAsync();
        return admin;
    }


    public Task<bool> IsSetUp()
    {
        return Task.FromResult(State.IsSetup);
    }

    private async Task<UserDto> CreateUserWithRole(string login, string passHash, List<string> roles)
    {
        var lowerLogin = login.ToLower();
        var user = GrainFactory.GetGrain<IUserGrain>(lowerLogin);
        await user.SetAuthData(passHash);
        await user.AddRoles(roles);
        State.Logins.Add(lowerLogin);
        await WriteStateAsync();
        return await user.GetDto();
    }
}