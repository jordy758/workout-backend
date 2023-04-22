using Workout.Domain.Models;
using Workout.Domain.WorkoutPlanAggregate.Entities;
using Workout.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Workout.Domain.WorkoutPlanAggregate;

public sealed class WorkoutPlan : AggregateRoot<WorkoutPlanId>
{
    private readonly List<WorkoutPlanSection> _sections = new();
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<WorkoutPlanSection> Sections => _sections.AsReadOnly();

    private WorkoutPlan(WorkoutPlanId workoutPlanId, string name, string description) : base(workoutPlanId)
    {
        Name = name;
        Description = description;
    }

    public void AddSection(WorkoutPlanSection section)
    {
        _sections.Add(section);
    }

    public static WorkoutPlan Create(string name, string description)
    {
        return new WorkoutPlan(WorkoutPlanId.CreateUnique(), name, description);
    }
    
    private WorkoutPlan()
    {
    }
}