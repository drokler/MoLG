using Dto.User;

namespace Domain.User;

public interface IUserAggregateGrain: IGrainWithIntegerKey
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto> CreateUser();
}