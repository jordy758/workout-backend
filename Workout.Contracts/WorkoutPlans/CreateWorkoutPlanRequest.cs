namespace Workout.Contracts.WorkoutPlans;

public record CreateWorkoutPlanRequest(
    string Name,
    string Description,
    IEnumerable<CreateWorkoutPlanRequest.WorkoutPlanSection> Sections)
{
    public record WorkoutPlanSection(
        string Name,
        string Description,
        IEnumerable<ExerciseInstruction> ExerciseInstructions);

    public record ExerciseInstruction(Guid ExerciseId, int Sets, int Reps, string? Description = null);
}