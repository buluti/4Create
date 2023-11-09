using _4Create.Domain.Interfaces;
using _4Create.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Database Context Dependancy Injection
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        
        var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName};User Id={dbUser};Password={dbPassword};encrypt=False";
        
        services.AddDbContext<ApplicationDbContext>(
            (sp, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
                });
            });

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}