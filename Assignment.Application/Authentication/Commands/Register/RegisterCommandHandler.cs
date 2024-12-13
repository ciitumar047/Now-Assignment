using Assignment.Application.Authentication.Common;
using Assignment.Application.Common.Interfaces.Authentication;
using Assignment.Application.Common.Interfaces.Persistence.Commands;
using Assignment.Application.Common.Interfaces.Persistence.Query;
using Assignment.Application.Common.Services;
using Assignment.Domain.Entities;

namespace Assignment.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse> // Request Command Handler the request and register the user
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(IUserCommandRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, 
        IUserQueryRepository userQueryRepository, IPasswordHasher passwordHasher)
    {

        _jwtTokenGenerator = jwtTokenGenerator;
        _userCommandRepository = userRepository;
        _userQueryRepository = userQueryRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userQueryRepository.GetByEmail(request.Username) is not null)
        {
            throw new Exception("User already exists");
        }
        var hashedPassword = _passwordHasher.HashPassword(request.Password);
        var user = new User
        {
            Username = request.Username,
            Password = hashedPassword,
            FirstName=request.FirstName,
            LastName=request.LastName,
            Device=request.Device,
            IpAddress=request.IpAddress,
            LastLoginTime=request.LastLoginTime,
            Balance=request.Balance,
        };
        if (await _userQueryRepository.GetByEmail(user.Username) is not null)
        {
            throw new Exception("User already exists");
        }

        var newUser = await _userCommandRepository.AddAsync(user);

        //var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResponse(newUser.UserId,"Success");
    }
}
