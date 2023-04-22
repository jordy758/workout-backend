namespace Workout.Application.Exercises.Common;

public record ExerciseResult(
    Guid Id, 
    string Name, 
    string Description, 
    IEnumerable<string> TargetedMuscles);