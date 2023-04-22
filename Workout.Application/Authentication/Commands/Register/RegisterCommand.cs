using ErrorOr;
using MediatR;
using Workout.Application.Authentication.Common;

namespace Workout.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;