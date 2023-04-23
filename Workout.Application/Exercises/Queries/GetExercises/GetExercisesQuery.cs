using MediatR;
using Workout.Application.Exercises.Common;

namespace Workout.Application.Exercises.Queries.GetExercises;

public record GetExercisesQuery : IRequest<IEnumerable<ExerciseResult>>;