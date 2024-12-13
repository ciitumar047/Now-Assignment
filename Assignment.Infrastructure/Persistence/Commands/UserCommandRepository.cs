using Assignment.Application.Common.Interfaces.Persistence.Commands;
using Assignment.Domain.Entities;
using Assignment.Infrastructure.DataContext;
using Assignment.Infrastructure.Persistence.Base;

namespace Assignment.Infrastructure.Persistence.Commands;
public class UserCommandRepository : CommandRepository<User>, IUserCommandRepository
{
    public UserCommandRepository(EfCoreContext context) : base(context)
    {

    }
}

