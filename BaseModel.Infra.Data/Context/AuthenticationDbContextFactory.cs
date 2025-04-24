using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BaseModel.Infra.Data.Context
{
    public class AuthenticationDbContextFactory : IDesignTimeDbContextFactory<AuthenticationDbContext>
    {
        public AuthenticationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "BaseModel.WebAPI");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AuthenticationDbContext>();
            var connectionString = configuration.GetConnectionString("AuthenticationConnection");

            optionsBuilder.UseNpgsql(connectionString);
            return new AuthenticationDbContext(optionsBuilder.Options);
        }
    }
}