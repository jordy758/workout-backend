using Microsoft.EntityFrameworkCore;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.WorkoutPlanAggregate;

namespace Workout.Infrastructure.Persistence.Repositories;

public class WorkoutPlanRepository : IWorkoutPlanRepository
{
    private readonly WorkoutDbContext _dbContext;

    public WorkoutPlanRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(WorkoutPlan workoutPlan)
    {
        await _dbContext.WorkoutPlans.AddAsync(workoutPlan);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkoutPlan>> GetAllAsync()
    {
        return await _dbContext.WorkoutPlans.ToListAsync();
    }
}