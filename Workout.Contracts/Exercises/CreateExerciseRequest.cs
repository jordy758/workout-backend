namespace Workout.Contracts.Exercises;

public record CreateExerciseRequest(
    string Name, 
    string Description, 
    IEnumerable<string> TargetedMuscles);