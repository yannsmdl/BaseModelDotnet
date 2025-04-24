using Microsoft.Extensions.DependencyInjection;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjectionCors
    {
        public static IServiceCollection AddInfrastructureCors(
            this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}