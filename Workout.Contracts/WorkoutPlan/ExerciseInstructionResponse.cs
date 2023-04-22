using Workout.Contracts.Exercise;

namespace Workout.Contracts.WorkoutPlan;

public record ExerciseInstructionResponse(
    Guid Id, 
    string? Description, 
    int Sets, 
    int Reps, 
    ExerciseResponse Exercise);