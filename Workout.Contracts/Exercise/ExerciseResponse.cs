namespace Workout.Contracts.Exercise;

public record ExerciseResponse(
    Guid Id, 
    string Name, 
    string Description, 
    IEnumerable<string> TargetedMuscles);