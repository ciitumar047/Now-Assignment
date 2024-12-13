using Assignment.Domain.Entities;

namespace Assignment.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
