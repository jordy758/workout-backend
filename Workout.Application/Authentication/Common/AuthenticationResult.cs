using Workout.Domain.User;

namespace Workout.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);