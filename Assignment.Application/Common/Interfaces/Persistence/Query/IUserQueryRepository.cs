using Assignment.Application.Common.Interfaces.Persistence.Base;
using Assignment.Domain.Entities;

namespace Assignment.Application.Common.Interfaces.Persistence.Query;

public interface IUserQueryRepository : IQueryRepository<User>
{
}
