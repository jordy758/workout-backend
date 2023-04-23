using MediatR;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Exercises.Common;
using Workout.Application.Extensions;

namespace Workout.Application.Exercises.Queries.GetExercises;

public class GetExercisesQueryHandler : IRequestHandler<GetExercisesQuery, IEnumerable<ExerciseResult>>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExercisesQueryHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<IEnumerable<ExerciseResult>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetAllAsync();
        return exercises.Select(exercise => exercise.MapToResult());
    }
}