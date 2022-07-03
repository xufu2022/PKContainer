using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KP.Infrastructure.Services;
using KP.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KP.Infrastructure.Configuration;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString,
        bool isDevelopment
    )
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null");
        }

        services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
        services.AddDbContext<KpiDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(
                    typeof(ServiceRegistration).Assembly.FullName);
            });
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
            else
            {
                //TODO: adding compile model
            }
        });

        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped(typeof(IDirectionsOfTravelService), typeof(DirectionsOfTravelService));
        return services;
    }
}