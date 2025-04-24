using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BaseModel.Infra.Data.Context
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "BaseModel.WebAPI");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("TenantConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new TenantDbContext(optionsBuilder.Options, tenantProvider: null);
        }
    }
}