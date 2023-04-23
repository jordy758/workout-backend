using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;

namespace Workout.Application.Common.Interfaces.Persistence;

public interface IExerciseRepository
{
    Task AddAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise> GetByIdAsync(ExerciseId id);
    Task<IEnumerable<Exercise>> GetByIdsAsync(List<ExerciseId> ids);
}