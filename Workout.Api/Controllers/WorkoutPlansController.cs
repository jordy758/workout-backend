using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workout.Api.Extensions;
using Workout.Application.WorkoutPlan.Commands.CreateWorkoutPlan;
using Workout.Application.WorkoutPlan.Queries.GetWorkoutPlans;
using Workout.Contracts.WorkoutPlan;

namespace Workout.Api.Controllers;

[Route("workout-plans")]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
public class WorkoutPlansController : ApiController
{
    private readonly ISender _sender;

    public WorkoutPlansController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WorkoutPlanResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAll()
    {
        var workoutPlansResults = await _sender.Send(new GetWorkoutPlansQuery());
        return Ok(workoutPlansResults.Select(workoutPlansResult => workoutPlansResult.MapToResponse()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(WorkoutPlanResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create()
    {
        var response = await _sender.Send(new CreateWorkoutPlanCommand());
        return response.Match(
            authResult => Ok(authResult.MapToResponse()),
            errors => Problem(errors));
    }
}