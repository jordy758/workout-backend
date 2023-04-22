using Workout.Domain.Models;
using Workout.Domain.WorkoutPlan.Entities;
using Workout.Domain.WorkoutPlan.ValueObjects;

namespace Workout.Domain.WorkoutPlan;

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