using Workout.Domain.Models;

namespace Workout.Domain.ExerciseAggregate.ValueObjects;

public sealed class ExerciseId : ValueObject
{
    public Guid Value { get; }

    private ExerciseId(Guid value)
    {
        Value = value;
    }

    public static ExerciseId Create(Guid value)
    {
        return new ExerciseId(value);
    }
    
    public static ExerciseId CreateUnique()
    {
        return new ExerciseId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}