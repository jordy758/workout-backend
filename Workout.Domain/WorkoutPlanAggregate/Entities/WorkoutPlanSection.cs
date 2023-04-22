using Workout.Domain.Models;
using Workout.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Workout.Domain.WorkoutPlanAggregate.Entities;

public class WorkoutPlanSection : Entity<WorkoutPlanSectionId>
{
    private readonly List<ExerciseInstruction> _exerciseInstructions = new();
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<ExerciseInstruction> ExerciseInstructions => _exerciseInstructions.AsReadOnly();

    private WorkoutPlanSection(WorkoutPlanSectionId workoutPlanSectionId, string name, string description) 
        : base(workoutPlanSectionId)
    {
        Name = name;
        Description = description;
    }

    public void AddExercise(ExerciseInstruction exercise)
    {
        _exerciseInstructions.Add(exercise);
    }

    public void AddExercises(IEnumerable<ExerciseInstruction> exercises)
    {
        _exerciseInstructions.AddRange(exercises);
    }

    public static WorkoutPlanSection Create(string name, string description)
    {
        return new WorkoutPlanSection(WorkoutPlanSectionId.CreateUnique(), name, description);
    }

    private WorkoutPlanSection()
    {
    }
}