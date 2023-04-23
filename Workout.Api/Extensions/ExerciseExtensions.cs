using Workout.Application.Exercises.Commands;
using Workout.Application.Exercises.Common;
using Workout.Contracts.Exercises;

namespace Workout.Api.Extensions;

public static class ExerciseExtensions
{
    public static ExerciseResponse MapToResponse(this ExerciseResult exerciseResult)
    {
        return new ExerciseResponse(
            exerciseResult.Id,
            exerciseResult.Name,
            exerciseResult.Description,
            exerciseResult.TargetedMuscles);
    }

    public static CreateExerciseCommand MapToCommand(this CreateExerciseRequest createExerciseRequest)
    {
        return new CreateExerciseCommand(
            createExerciseRequest.Name,
            createExerciseRequest.Description,
            createExerciseRequest.TargetedMuscles);
    }
}