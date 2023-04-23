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
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ExerciseResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ExerciseResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateExerciseRequest request)
    {
        var exerciseResult = await _sender.Send(request.MapToCommand());
        return exerciseResult.Match(
            exerciseResult =>
            {
                var exerciseResponse = exerciseResult.MapToResponse();
                return CreatedAtAction(
                    nameof(GetById), 
                    new { id = exerciseResponse.Id }, 
                    exerciseResponse);
            },
            errors => Problem(errors));
    }
}