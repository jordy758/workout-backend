using ErrorOr;
using MediatR;
using Workout.Application.WorkoutPlans.Common;

namespace Workout.Application.WorkoutPlans.Commands.CreateWorkoutPlan;

public record CreateWorkoutPlanCommand(
    string Name,
    string Description,
    IEnumerable<CreateWorkoutPlanCommand.WorkoutPlanSection> Sections) : IRequest<ErrorOr<WorkoutPlanResult>>
{
    public record WorkoutPlanSection(
        string Name,
        string Description,
        IEnumerable<ExerciseInstruction> ExerciseInstructions);

    public record ExerciseInstruction(Guid ExerciseId, int Sets, int Reps, string? Description = null);
}
