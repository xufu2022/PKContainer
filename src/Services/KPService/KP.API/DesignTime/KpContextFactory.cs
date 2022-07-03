using KP.Infrastructure;
using KP.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KP.API.DesignTime;

public class KpContextFactory : IDesignTimeDbContextFactory<KpiDbContext>
{
    private const string KpConnectionString = "KpConnection";
    
    public KpiDbContext CreateDbContext(string[] args)
    {
        //var connectionString = Environment.GetEnvironmentVariable(KpConnectionString);
        var connectionString = GetAppConfiguration().GetConnectionString(KpConnectionString);

        //string connectionString = builder.Configuration.GetConnectionString("KpConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException(
                $"Please set the environment variable {KpConnectionString}");
        }
        var options = new DbContextOptionsBuilder<KpiDbContext>()
            .UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(
                    typeof(ServiceRegistration).Assembly.FullName);
            })
            .Options;
        return new KpiDbContext(options, new DesignTimeModelConfiguration());
    }

    IConfiguration GetAppConfiguration()
    {
        var environmentName =
            Environment.GetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();

        return builder.Build();
    }


}