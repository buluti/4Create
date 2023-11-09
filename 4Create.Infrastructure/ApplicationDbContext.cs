using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork    
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Ignore<Type>();
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<SystemLog>? SystemLogs { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
