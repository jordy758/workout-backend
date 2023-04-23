using Microsoft.EntityFrameworkCore;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;

namespace Workout.Infrastructure.Persistence.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WorkoutDbContext _dbContext;

    public ExerciseRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Exercise exercise)
    {
        await _dbContext.Exercises.AddAsync(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _dbContext.Exercises
            .ToListAsync();
    }

    public async Task<Exercise> GetByIdAsync(ExerciseId id)
    {
        return await _dbContext.Exercises
            .SingleAsync(exercise => exercise.Id == id);
    }

    public async Task<IEnumerable<Exercise>> GetByIdsAsync(List<ExerciseId> ids)
    {
        var exercises = await _dbContext.Exercises
            .Where(exercise => ids.Contains(exercise.Id))
            .ToListAsync();

        if (exercises.Count != ids.Count)
        {
            throw new ArgumentException($"Tried fetching {ids.Count} exercises by id, but only found {exercises.Count}");
        }

        return exercises;
    }
}