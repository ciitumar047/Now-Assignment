using Assignment.Application.Common.Interfaces.Persistence.Base;
using Assignment.Infrastructure.DataContext;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Assignment.Infrastructure.Persistence.Base;

public class QueryRepository<T> : DapperContext, IQueryRepository<T> where T : class
{
    public QueryRepository(IConfiguration configuration)
        : base(configuration)
    {

    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using (var db = CreateConnection())
        {
            var query = "SELECT * FROM Users";
            return await db.QueryAsync<T>(query);
        }
    }

    public async Task<T> GetByEmail(string email)
    {
        using (var db = CreateConnection())
        {
            var query = "SELECT * FROM Users WHERE Username = @email";
            var result = await db.QuerySingleOrDefaultAsync<T>(query, new { email });
            return result;
        }
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        using (var db = CreateConnection())
        {
            var query = $"SELECT * FROM Users WHERE UserId = @id";
            return await db.QuerySingleOrDefaultAsync<T>(query, new { id });
        }
    }
}
