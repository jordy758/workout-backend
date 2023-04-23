namespace Workout.Contracts.Exercises;

public record ExerciseResponse(
    Guid Id, 
    string Name, 
    string Description, 
    IEnumerable<string> TargetedMuscles);