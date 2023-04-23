using Workout.Application.Exercises.Common;

namespace Workout.Application.WorkoutPlans.Common;

public record WorkoutPlanResult(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<WorkoutPlanSectionResult> Sections);

public record WorkoutPlanSectionResult(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<ExerciseInstructionResult> ExerciseInstructions);

public record ExerciseInstructionResult(
    Guid Id, 
    string? Description, 
    int Sets, 
    int Reps, 
    ExerciseResult Exercise);