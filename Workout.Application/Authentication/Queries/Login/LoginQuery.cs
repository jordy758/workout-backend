using ErrorOr;
using MediatR;
using Workout.Application.Authentication.Common;

namespace Workout.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;