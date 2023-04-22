using Workout.Application.Exercises.Common;
using Workout.Application.WorkoutPlan.Common;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;

namespace Workout.Application.Extensions;

public static class WorkoutPlanExtensions
{
    public static IEnumerable<ExerciseId> GetAllExerciseIds(
        this Domain.WorkoutPlanAggregate.WorkoutPlan workoutPlan)
    {
        return workoutPlan
            .Sections
            .SelectMany(s => s.ExerciseInstructions)
            .Select(e => e.ExerciseId)
            .Distinct();
    }

    public static WorkoutPlanResult MapToResult(
        this Domain.WorkoutPlanAggregate.WorkoutPlan workoutPlan, 
        IEnumerable<Exercise> exercises)
    {
        
        var sections = workoutPlan.Sections.Select(section =>
        {
            var workoutPlanExercises = section.ExerciseInstructions.Select(workoutPlanExercise =>
            {
                var exercise = exercises.Single(e => e.Id == workoutPlanExercise.ExerciseId);
                var exerciseData = new ExerciseResult(
                    exercise.Id.Value,
                    exercise.Name,
                    exercise.Description,
                    exercise.TargetedMuscles);
                
                return new ExerciseInstructionResult(
                    workoutPlanExercise.Id.Value,
                    workoutPlanExercise.Description,
                    workoutPlanExercise.Sets,
                    workoutPlanExercise.Reps,
                    exerciseData);
            });

            return new WorkoutPlanSectionResult(
                section.Id.Value,
                section.Name,
                section.Description,
                workoutPlanExercises);
        });

        return new WorkoutPlanResult(workoutPlan.Id.Value, workoutPlan.Name, workoutPlan.Description, sections);
    }
}