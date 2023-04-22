using Workout.Domain.Models;

namespace Workout.Domain.WorkoutPlanAggregate.ValueObjects;

public sealed class WorkoutPlanSectionId : ValueObject
{
    public Guid Value { get; }

    private WorkoutPlanSectionId(Guid value)
    {
        Value = value;
    }

    public static WorkoutPlanSectionId CreateUnique()
    {
        return new WorkoutPlanSectionId(Guid.NewGuid());
    }

    public static WorkoutPlanSectionId Create(Guid value)
    {
        return new WorkoutPlanSectionId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}