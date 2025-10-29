using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using University.Infrastructure.Context;

namespace University.Infrastructure.Factory
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=UniversityDb;Trusted_Connection=True;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly("University.Infrastructure");
            });

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}