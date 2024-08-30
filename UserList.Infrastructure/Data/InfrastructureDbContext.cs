using Microsoft.EntityFrameworkCore;
using UserList.Infrastructure.Models;

namespace UserList.Infrastructure.Data
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        
    }
}
