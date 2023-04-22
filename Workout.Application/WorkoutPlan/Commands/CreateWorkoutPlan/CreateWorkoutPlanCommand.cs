using ErrorOr;
using MediatR;
using Workout.Application.WorkoutPlan.Common;

namespace Workout.Application.WorkoutPlan.Commands.CreateWorkoutPlan;

public record CreateWorkoutPlanCommand : IRequest<ErrorOr<WorkoutPlanResult>>;