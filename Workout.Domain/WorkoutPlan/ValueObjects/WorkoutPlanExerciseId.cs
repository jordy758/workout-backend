using Workout.Domain.Models;

namespace Workout.Domain.WorkoutPlan.ValueObjects;

public sealed class WorkoutPlanExerciseId : ValueObject
{
    public Guid Value { get; }

    private WorkoutPlanExerciseId(Guid value)
    {
        Value = value;
    }

    public static WorkoutPlanExerciseId CreateUnique()
    {
        return new WorkoutPlanExerciseId(Guid.NewGuid());
    }

    public static WorkoutPlanExerciseId Create(Guid value)
    {
        return new WorkoutPlanExerciseId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}