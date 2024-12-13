using Assignment.Application.Authentication.Queries.Login;
using FluentValidation;

namespace Assignment.Application.Authentication.Queries.Balance;

public class BalanceQueryValidator : AbstractValidator<BalanceQuery> //Query Validator
{
    public BalanceQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
