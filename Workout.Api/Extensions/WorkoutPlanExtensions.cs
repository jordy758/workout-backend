using Workout.Application.WorkoutPlans.Commands.CreateWorkoutPlan;
using Workout.Application.WorkoutPlans.Common;
using Workout.Contracts.Exercises;
using Workout.Contracts.WorkoutPlans;

namespace Workout.Api.Extensions;

public static class WorkoutPlanExtensions
{
    public static CreateWorkoutPlanCommand MapToCommand(this CreateWorkoutPlanRequest request)
    {
        return new CreateWorkoutPlanCommand(
            request.Name,
            request.Description,
            request.Sections.Select(section => new CreateWorkoutPlanCommand.WorkoutPlanSection(
                section.Name,
                section.Description,
                section.ExerciseInstructions.Select(instruction => new CreateWorkoutPlanCommand.ExerciseInstruction(
                    instruction.ExerciseId,
                    instruction.Sets,
                    instruction.Reps,
                    instruction.Description)))));
    }
    
    public static WorkoutPlanResponse MapToResponse(this WorkoutPlanResult result)
    {
        return new WorkoutPlanResponse(result.Id,
            result.Name,
            result.Description,
            result.Sections.Select(section => new WorkoutPlanResponse.WorkoutPlanSectionResponse(
                section.Id,
                section.Name,
                section.Description,
                section.ExerciseInstructions.Select(exerciseInstruction => new WorkoutPlanResponse.ExerciseInstructionResponse(
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