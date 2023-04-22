namespace Workout.Contracts.WorkoutPlan;

public record WorkoutPlanSectionResponse(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<ExerciseInstructionResponse> ExerciseInstructions);