using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;

namespace Workout.Application.Common.Interfaces.Persistence;

public interface IExerciseRepository
{
    Task AddAsync(Exercise exercise);
    Task<Exercise> GetByIdAsync(ExerciseId id);
    Task<IEnumerable<Exercise>> GetByIdsAsync(IEnumerable<ExerciseId> ids);
}