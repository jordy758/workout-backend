using ErrorOr;
using MediatR;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Extensions;
using Workout.Application.WorkoutPlans.Common;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.ExerciseAggregate.ValueObjects;
using Workout.Domain.WorkoutPlanAggregate;
using Workout.Domain.WorkoutPlanAggregate.Entities;

namespace Workout.Application.WorkoutPlans.Commands.CreateWorkoutPlan;

public class CreateWorkoutPlanCommandHandler :
    IRequestHandler<CreateWorkoutPlanCommand, ErrorOr<WorkoutPlanResult>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IWorkoutPlanRepository _workoutPlanRepository;

    public CreateWorkoutPlanCommandHandler(IExerciseRepository exerciseRepository, IWorkoutPlanRepository workoutPlanRepository)
    {
        _exerciseRepository = exerciseRepository;
        _workoutPlanRepository = workoutPlanRepository;
    }

    public async Task<ErrorOr<WorkoutPlanResult>> Handle(CreateWorkoutPlanCommand request, CancellationToken cancellationToken)
    {
        var workoutPlan = WorkoutPlan.Create(request.Name, request.Description);
        var sections = request.Sections.Select(
            section =>
            {
                var workoutPlanSection = WorkoutPlanSection.Create(section.Name, section.Description);
                
                var exerciseInstructions = section.ExerciseInstructions.Select(
                    exerciseInstruction => ExerciseInstruction.Create(
                        ExerciseId.Create(exerciseInstruction.ExerciseId),
                        exerciseInstruction.Sets,
                        exerciseInstruction.Reps,
                        exerciseInstruction.Description));
                
                workoutPlanSection.AddExercises(exerciseInstructions);
                return workoutPlanSection;
            }).ToList();
        
        sections.ForEach(section => workoutPlan.AddSection(section));
        
        var exercises = await _exerciseRepository.GetByIdsAsync(
            workoutPlan.GetAllExerciseIds().ToList());
        
        await _workoutPlanRepository.AddAsync(workoutPlan);
        return workoutPlan.MapToResult(exercises);
    }
}