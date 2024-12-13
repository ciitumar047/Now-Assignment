using Assignment.Application.Common.Interfaces.Authentication;
using Assignment.Application.Common.Interfaces.Persistence.Commands;
using Assignment.Application.Common.Interfaces.Persistence.Query;
using Assignment.Application.Common.Services;

namespace Assignment.Application.Authentication.Queries.Login;
public class LoginQueryHandler :
    IRequestHandler<LoginQuery, LoginUserReponse> // Login Query Handler
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IPasswordHasher _passwordHasher;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserQueryRepository userQueryRepository, 
        IUserCommandRepository userCommandRepository, IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginUserReponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userQueryRepository.GetByEmail(query.Email);

        if (user is null)
        {
            throw new Exception("User does not exist");
        }

        // Verify the password using the hashing service
        if (!_passwordHasher.VerifyPassword(query.Password, user.Password))
        {
            throw new Exception("Invalid password");
        }
        // Generate a JWT token for the user
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Return the login response
        return new LoginUserReponse(user.UserId, user.FirstName, user.LastName, token);
    }
}

