using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EssentialCore.DbContexts
{
    public class SqlServerDbContext : DbContext
    {
        private List<Assembly> assemblies;
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
            assemblies = new List<Assembly>();
            assemblies.Add(this.GetType().Assembly);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            foreach(var assembly in assemblies)
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public void AddConfigurations(Assembly assembly) => assemblies.Add(assembly);
    }
}
