using ErrorOr;
using MediatR;
using Workout.Application.Authentication.Common;
using Workout.Application.Common.Interfaces.Authentication;
using Workout.Application.Common.Interfaces.Persistence;
using Workout.Domain.Common.Errors;
using Workout.Domain.UserAggregate;

namespace Workout.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);

        await _userRepository.AddAsync(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}