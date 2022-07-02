using KP.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KP.Infrastructure.Configuration;

internal class SqlModelConfiguration : IModelConfiguration
{
    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
    }
}
