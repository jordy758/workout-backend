using Workout.Domain.UserAggregate;

namespace Workout.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetUserByEmailAsync(string email);
}