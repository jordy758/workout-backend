using Workout.Domain.Models;

namespace Workout.Domain.WorkoutPlanAggregate.ValueObjects;

public sealed class ExerciseInstructionId : ValueObject
{
    public Guid Value { get; }

    private ExerciseInstructionId(Guid value)
    {
        Value = value;
    }

    public static ExerciseInstructionId CreateUnique()
    {
        return new ExerciseInstructionId(Guid.NewGuid());
    }

    public static ExerciseInstructionId Create(Guid value)
    {
        return new ExerciseInstructionId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}