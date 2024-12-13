using Assignment.Application.Authentication.Common;

namespace Assignment.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
     string Username,
     string Password,string FirstName,string LastName,string Device,
     string IpAddress ,DateTime LastLoginTime,decimal Balance) : IRequest<AuthenticationResponse>; // ReqisterCommand For Register Param
}
