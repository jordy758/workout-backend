using Workout.Application.Exercises.Common;
using Workout.Domain.ExerciseAggregate;

namespace Workout.Application.Extensions;

public static class ExerciseExtensions
{
    public static ExerciseResult MapToResult(this Exercise exercise)
    {
        return new ExerciseResult(
            exercise.Id.Value,
            exercise.Name,
            exercise.Description,
            exercise.TargetedMuscles);
    }
}