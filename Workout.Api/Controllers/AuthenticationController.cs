using Workout.Application.Authentication.Commands.Register;
using Workout.Application.Authentication.Queries.Login;
using Workout.Contracts.Authentication;
using Workout.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workout.Api.Extensions;

namespace Workout.Api.Controllers;

[Route("auth")]
[ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResponse = await _mediator.Send(query);

        if (authResponse.IsError && authResponse.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResponse.FirstError.Description);
        }

        return authResponse.Match(
            authResult => Ok(authResult.MapToResponse()),
            errors => Problem(errors));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        var authResponse = await _mediator.Send(command);

        return authResponse.Match(
            authResult => Ok(authResult.MapToResponse()),
            errors => Problem(errors));
    }
    
}