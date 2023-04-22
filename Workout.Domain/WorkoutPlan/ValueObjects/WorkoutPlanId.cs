using Workout.Domain.Models;

namespace Workout.Domain.WorkoutPlan.ValueObjects;

public sealed class WorkoutPlanId : ValueObject
{
    public Guid Value { get; }

    private WorkoutPlanId(Guid value)
    {
        Value = value;
    }

    public static WorkoutPlanId CreateUnique()
    {
        return new WorkoutPlanId(Guid.NewGuid());
    }
    
    public static WorkoutPlanId Create(Guid value)
    {
        return new WorkoutPlanId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}