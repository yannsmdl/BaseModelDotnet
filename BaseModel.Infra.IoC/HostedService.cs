using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Account;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseModel.Infra.IoC
{
    public class SeedUserHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public SeedUserHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
        seeder.SeedRoles();
        seeder.SeedUsers();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
}