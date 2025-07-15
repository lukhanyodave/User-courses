using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Skunkworks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace Skunkworks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
      this IServiceCollection services,
      IConfiguration configuration) =>
      services
          .AddDatabase(configuration);

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<DemoDbContext>((provider, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
