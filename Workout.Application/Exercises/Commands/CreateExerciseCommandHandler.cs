using ErrorOr;
using MediatR;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Application.Exercises.Common;
using Workout.Application.Extensions;
using Workout.Domain.ExerciseAggregate;

namespace Workout.Application.Exercises.Commands;

public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ErrorOr<ExerciseResult>>
{
    private readonly IExerciseRepository _exerciseRepository;

    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<ErrorOr<ExerciseResult>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = Exercise.Create(request.Name, request.Description, request.TargetedMuscles);
        await _exerciseRepository.AddAsync(exercise);
        return exercise.MapToResult();
    }
}