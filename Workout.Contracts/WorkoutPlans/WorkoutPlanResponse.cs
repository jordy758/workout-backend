using Workout.Contracts.Exercises;

namespace Workout.Contracts.WorkoutPlans;

public record WorkoutPlanResponse(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<WorkoutPlanResponse.WorkoutPlanSectionResponse> Sections)
{
    public record WorkoutPlanSectionResponse(
        Guid Id,
        string Name,
        string Description,
        IEnumerable<ExerciseInstructionResponse> ExerciseInstructions);
    
    public record ExerciseInstructionResponse(
        Guid Id, 
        string? Description, 
        int Sets, 
        int Reps, 
        ExerciseResponse Exercise);
}