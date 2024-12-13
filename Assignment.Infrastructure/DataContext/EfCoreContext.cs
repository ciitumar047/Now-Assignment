using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.DataContext;

public class EfCoreContext : DbContext
{
    public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
}
