using ErrorOr;
using MediatR;
using Workout.Application.Authentication.Common;
using Workout.Application.Common.Interfaces.Authentication;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.Common.Errors;

namespace Workout.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Email) is not { } user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}