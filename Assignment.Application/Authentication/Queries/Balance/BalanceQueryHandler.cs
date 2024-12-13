using Assignment.Application.Common.Interfaces.Authentication;
using Assignment.Application.Common.Interfaces.Persistence.Commands;
using Assignment.Application.Common.Interfaces.Persistence.Query;

namespace Assignment.Application.Authentication.Queries.Balance;

public class BalanceQueryHandler:
IRequestHandler<BalanceQuery, BalanceResponse> // Query Handler
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;


    public BalanceQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserQueryRepository userQueryRepository, 
        IUserCommandRepository userCommandRepository, IJwtTokenGenerator jwtTokenGenerator2)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        _jwtTokenGenerator = jwtTokenGenerator2;
    }

    public async Task<BalanceResponse> Handle(BalanceQuery query, CancellationToken cancellationToken)
    {
        var user = await _userQueryRepository.GetByIdAsync(query.UserId);

        if (user is null)
        {
            throw new Exception("User does not exist");
        }
        return new BalanceResponse(user.Balance.ToString());
    }
}
