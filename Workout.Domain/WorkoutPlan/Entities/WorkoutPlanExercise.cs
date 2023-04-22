using Workout.Domain.Exercise.ValueObjects;
using Workout.Domain.Models;
using Workout.Domain.WorkoutPlan.ValueObjects;

namespace Workout.Domain.WorkoutPlan.Entities;

public sealed class WorkoutPlanExercise : Entity<WorkoutPlanExerciseId>
{
    public ExerciseId ExerciseId { get; }
    public int Sets { get; }
    public int Reps { get; }
    public string? Description { get; }

    private WorkoutPlanExercise(WorkoutPlanExerciseId workoutPlanExerciseId,
        ExerciseId exerciseId,
        int sets,
        int reps,
        string? description = null) : base(workoutPlanExerciseId)
    {
        ExerciseId = exerciseId;
        Sets = sets;
        Reps = reps;
        Description = description;
    }

    public static WorkoutPlanExercise Create(ExerciseId exerciseId, int sets, int reps, string? description = null)
    {
        return new WorkoutPlanExercise(WorkoutPlanExerciseId.CreateUnique(), exerciseId, sets, reps, description);
    }

    private WorkoutPlanExercise()
    {
    }
}