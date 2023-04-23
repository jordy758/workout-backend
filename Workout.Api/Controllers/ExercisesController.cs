using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workout.Api.Extensions;
using Workout.Application.Exercises.Queries.GetExercises;
using Workout.Contracts.Exercises;

namespace Workout.Api.Controllers;

[Route("exercises")]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
public class ExercisesController : ApiController
{
    private readonly ISender _sender;

    public ExercisesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ExerciseResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAll()
    {
        var exercisesResult = await _sender.Send(new GetExercisesQuery());
        return Ok(exercisesResult.Select(exerciseResult => exerciseResult.MapToResponse()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ExerciseResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateExerciseRequest request)
    {
        var result = await _sender.Send(request.MapToCommand());
        return result.Match(
            authResult => Ok(authResult.MapToResponse()),
            errors => Problem(errors));
    }
}