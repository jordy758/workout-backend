using Microsoft.EntityFrameworkCore;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.UserAggregate;

namespace Workout.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WorkoutDbContext _dbContext;
    
    public UserRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}