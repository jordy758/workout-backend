using MediatR;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Extensions;
using Workout.Application.WorkoutPlans.Common;

namespace Workout.Application.WorkoutPlans.Queries.GetWorkoutPlans;

public class GetWorkoutPlansQueryHandler : IRequestHandler<GetWorkoutPlansQuery, IEnumerable<WorkoutPlanResult>>
{
    private readonly IWorkoutPlanRepository _workoutPlanRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public GetWorkoutPlansQueryHandler(IWorkoutPlanRepository workoutPlanRepository, IExerciseRepository exerciseRepository)
    {
        _workoutPlanRepository = workoutPlanRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<IEnumerable<WorkoutPlanResult>> Handle(GetWorkoutPlansQuery request, CancellationToken cancellationToken)
    {
        var workoutPlans = (await _workoutPlanRepository.GetAllAsync()).ToList();

        var exercises = await _exerciseRepository.GetByIdsAsync(
            workoutPlans
                .SelectMany(workoutPlan => workoutPlan.GetAllExerciseIds())
                .ToList());
        
        return workoutPlans.Select(workoutPlan => workoutPlan.MapToResult(exercises));
    }
}