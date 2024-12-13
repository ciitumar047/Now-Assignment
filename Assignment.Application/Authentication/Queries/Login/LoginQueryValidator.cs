using Assignment.Application.Authentication.Queries.Login;
using FluentValidation;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty(); // Query Validator 
        RuleFor(x => x.Password).NotEmpty();
    }
}
