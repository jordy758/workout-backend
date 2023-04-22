using Workout.Domain.Models;
using Workout.Domain.WorkoutPlan.ValueObjects;

namespace Workout.Domain.WorkoutPlan.Entities;

public class WorkoutPlanSection : Entity<WorkoutPlanSectionId>
{
    private readonly List<WorkoutPlanExercise> _exercises = new();
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<WorkoutPlanExercise> Exercises => _exercises.AsReadOnly();

    private WorkoutPlanSection(WorkoutPlanSectionId workoutPlanSectionId, string name, string description) 
        : base(workoutPlanSectionId)
    {
        Name = name;
        Description = description;
    }

    public void AddExercise(WorkoutPlanExercise exercise)
    {
        _exercises.Add(exercise);
    }

    public void AddExercises(IEnumerable<WorkoutPlanExercise> exercises)
    {
        _exercises.AddRange(exercises);
    }

    public static WorkoutPlanSection Create(string name, string description)
    {
        return new WorkoutPlanSection(WorkoutPlanSectionId.CreateUnique(), name, description);
    }

    private WorkoutPlanSection()
    {
    }
}