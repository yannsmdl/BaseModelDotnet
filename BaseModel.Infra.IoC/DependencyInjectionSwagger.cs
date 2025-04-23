using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(c=>{
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' and your valid token in the text input below.\nExample: "
                });

                c.AddSecurityDefinition("X-Tenant-Url", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "X-Tenant-Url",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Your tenant host (e.g. tenant-a.localhost)",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "X-Tenant-Url"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            

            return services;
        }
    }
}