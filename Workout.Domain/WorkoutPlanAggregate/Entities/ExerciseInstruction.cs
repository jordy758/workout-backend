using Workout.Domain.ExerciseAggregate.ValueObjects;
using Workout.Domain.Models;
using Workout.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Workout.Domain.WorkoutPlanAggregate.Entities;

public sealed class ExerciseInstruction : Entity<ExerciseInstructionId>
{
    public ExerciseId ExerciseId { get; }
    public int Sets { get; }
    public int Reps { get; }
    public string? Description { get; }

    private ExerciseInstruction(ExerciseInstructionId exerciseInstructionId,
        ExerciseId exerciseId,
        int sets,
        int reps,
        string? description = null) : base(exerciseInstructionId)
    {
        ExerciseId = exerciseId;
        Sets = sets;
        Reps = reps;
        Description = description;
    }

    public static ExerciseInstruction Create(ExerciseId exerciseId, int sets, int reps, string? description = null)
    {
        return new ExerciseInstruction(ExerciseInstructionId.CreateUnique(), exerciseId, sets, reps, description);
    }

    private ExerciseInstruction()
    {
    }
}