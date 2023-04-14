using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EssentialCore.DbContexts
{
    public class SqlServerDbContext : DbContext
    {
        private ModelBuilder ModelBuilder { get; set; }
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.ModelBuilder = modelBuilder;

            this.ModelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public void AddConfigurations(Assembly assembly)
        {
            this.ModelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
