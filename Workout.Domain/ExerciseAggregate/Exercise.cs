using Workout.Domain.ExerciseAggregate.ValueObjects;
using Workout.Domain.Models;

namespace Workout.Domain.ExerciseAggregate;

public sealed class Exercise : AggregateRoot<ExerciseId>
{
    public string Name { get; }
    public string Description { get; }
    
    private readonly List<string> _targetedMuscles = new();
    public IReadOnlyList<string> TargetedMuscles => _targetedMuscles.AsReadOnly();

    private Exercise(ExerciseId exerciseId, string name, string description, IEnumerable<string> targetedMuscles) : base(exerciseId)
    {
        Name = name;
        Description = description;
        _targetedMuscles.AddRange(targetedMuscles);
    }

    public static Exercise Create(string name, string description, IEnumerable<string> targetedMuscles)
    {
        return new Exercise(ExerciseId.CreateUnique(), name, description, targetedMuscles);
    }
    
    private Exercise()
    {
    }
}