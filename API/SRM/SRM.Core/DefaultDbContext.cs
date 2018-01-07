using SRM.Core.Entities;
using SRM.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SRM.Core
{
    public class DefaultDbContext : IdentityDbContext<User, Role, int>
    { 
        public DefaultDbContext(DbContextOptions<DefaultDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DataContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>()
                .UseSqlServer("Data Source=DESKTOP-N6PC0RN\\SQLEXPRESS;MultipleActiveResultSets=True;Initial Catalog=srm;Integrated Security=True");

            return new DbContext(optionsBuilder.Options);
        }
    }
}
