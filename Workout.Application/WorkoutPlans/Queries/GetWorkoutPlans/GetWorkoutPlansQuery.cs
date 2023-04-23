using MediatR;
using Workout.Application.WorkoutPlans.Common;

namespace Workout.Application.WorkoutPlans.Queries.GetWorkoutPlans;

public record GetWorkoutPlansQuery : IRequest<IEnumerable<WorkoutPlanResult>>;