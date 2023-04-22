using Workout.Application.WorkoutPlan.Common;
using Workout.Contracts.Exercise;
using Workout.Contracts.WorkoutPlan;

namespace Workout.Api.Extensions;

public static class WorkoutPlanMapper
{
    public static WorkoutPlanResponse MapToResponse(this WorkoutPlanResult result)
    {
        return new WorkoutPlanResponse(result.Id,
            result.Name,
            result.Description,
            result.Sections.Select(section => new WorkoutPlanSectionResponse(
                section.Id,
                section.Name,
                section.Description,
                section.ExerciseInstructions.Select(exerciseInstruction => new ExerciseInstructionResponse(
                    exerciseInstruction.Id,
                    exerciseInstruction.Description,
                    exerciseInstruction.Sets,
                    exerciseInstruction.Reps,
                    new ExerciseResponse(
                        exerciseInstruction.Exercise.Id,
                        exerciseInstruction.Exercise.Name,
                        exerciseInstruction.Exercise.Description,
                        exerciseInstruction.Exercise.TargetedMuscles))))));
    }
}