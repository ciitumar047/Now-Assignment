using Assignment.Application.Common.Interfaces.Persistence.Base;
using Assignment.Domain.Entities;
namespace Assignment.Application.Common.Interfaces.Persistence.Commands;

public interface IUserCommandRepository : ICommandRepository<User>
{

}
