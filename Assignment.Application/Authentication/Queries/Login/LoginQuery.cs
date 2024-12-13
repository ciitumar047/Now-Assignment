using Assignment.Application.Authentication.Common;
namespace Assignment.Application.Authentication.Queries.Login;

public record LoginQuery(
string Email,
string Password) : IRequest<LoginUserReponse>;  // Login Query Request
