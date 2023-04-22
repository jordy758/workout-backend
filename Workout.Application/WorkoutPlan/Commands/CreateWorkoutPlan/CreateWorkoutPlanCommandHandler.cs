using ErrorOr;
using MediatR;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Extensions;
using Workout.Application.WorkoutPlan.Common;
using Workout.Domain.ExerciseAggregate;
using Workout.Domain.WorkoutPlanAggregate.Entities;

namespace Workout.Application.WorkoutPlan.Commands.CreateWorkoutPlan;

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
        var exercise = Exercise.Create("Plank", "Plank good", new[] { "Core" });
        await _exerciseRepository.AddAsync(exercise);
        
        var workoutPlan = Domain.WorkoutPlanAggregate.WorkoutPlan.Create("First one", "My perfect workout plan");
        var section = WorkoutPlanSection.Create("First section", "This is my first section");

        var planExercise = ExerciseInstruction.Create(exercise.Id, 10, 5);
        section.AddExercise(planExercise);

        workoutPlan.AddSection(section);
        await _workoutPlanRepository.AddAsync(workoutPlan);
        
        return workoutPlan.MapToResult(new [] { exercise });
    }
}