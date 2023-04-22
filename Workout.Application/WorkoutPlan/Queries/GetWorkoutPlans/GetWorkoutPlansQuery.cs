using MediatR;
using Workout.Application.WorkoutPlan.Common;

namespace Workout.Application.WorkoutPlan.Queries.GetWorkoutPlans;

public record GetWorkoutPlansQuery : IRequest<IEnumerable<WorkoutPlanResult>>;