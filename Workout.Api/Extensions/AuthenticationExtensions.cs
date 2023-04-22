using Workout.Application.Authentication.Common;
using Workout.Contracts.Authentication;

namespace Workout.Api.Extensions;

public static class AuthenticationExtensions
{
    public static AuthenticationResponse MapToResponse(this AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id.Value,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
    }
}