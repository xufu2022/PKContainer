using KP.Domain.Entities;
using KP.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KP.Infrastructure
{
    public partial class KpiDbContext : DbContext
    {
        private readonly IModelConfiguration _modelConfiguration;

        public KpiDbContext(DbContextOptions<KpiDbContext> options, IModelConfiguration modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KpiDbContext).Assembly);
            _modelConfiguration.ConfigureModel(modelBuilder);
        }
    }
}