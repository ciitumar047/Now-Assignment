using Assignment.Application.Common.Interfaces.Persistence.Query;
using Assignment.Domain.Entities;
using Assignment.Infrastructure.Persistence.Base;
using Microsoft.Extensions.Configuration;

namespace Assignment.Infrastructure.Persistence.Query;

public class UserQueryRepository : QueryRepository<User>, IUserQueryRepository
{
    public UserQueryRepository(IConfiguration configuration)
            : base(configuration)
    {

    }
}
