using Workout.Domain.UserAggregate;

namespace Workout.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);