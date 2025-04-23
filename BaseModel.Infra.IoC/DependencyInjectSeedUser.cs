using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjectHosted
    {
        public static IServiceCollection AddInfrastructureHosted(
            this IServiceCollection services)
        {
            services.AddHostedService<SeedUserHostedService>();

            return services;
        }
    }
}