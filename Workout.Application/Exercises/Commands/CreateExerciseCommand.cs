using ErrorOr;
using MediatR;
using Workout.Application.Exercises.Common;

namespace Workout.Application.Exercises.Commands;

public record CreateExerciseCommand(
    string Name, 
    string Description, 
    IEnumerable<string> TargetedMuscles): IRequest<ErrorOr<ExerciseResult>>;