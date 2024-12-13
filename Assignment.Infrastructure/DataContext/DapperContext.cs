using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Assignment.Infrastructure.DataContext;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext()
    {
    }
    protected DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }
        return new SqlConnection(connectionString); // Use SqlConnection for SQL Server
    }
}
