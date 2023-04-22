using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.User;

namespace Workout.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WorkoutDbContext _dbContext;
    
    public UserRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
    }
}