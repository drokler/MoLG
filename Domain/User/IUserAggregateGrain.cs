using Dto.User;

namespace Domain.User;

public interface IUserAggregateGrain: IGrainWithIntegerKey
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto> CreateUser(string login, string passHash);
    Task<bool> IsSetUp();
    Task<UserDto> CreateAdmin(string login, string pass);
}