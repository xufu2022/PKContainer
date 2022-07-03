using System.Drawing;
using System.Linq.Expressions;
using KP.Domain.Entities;
using KP.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KP.Infrastructure
{
    public class KpiDbContext : DbContext
    {
        private readonly IModelConfiguration _modelConfiguration;

        public KpiDbContext(DbContextOptions<KpiDbContext> options, IModelConfiguration modelConfiguration) :
            base(options)
        {
            _modelConfiguration = modelConfiguration;
            SavingChanges += KpiDbContext_SavingChanges;
        }

        private void KpiDbContext_SavingChanges(object? sender, SavingChangesEventArgs e)
        {
            UpdateAuditData();
        }

        private void UpdateAuditData()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is Kpi))
            {
                entry.Property("ModifiedOn").CurrentValue = DateTime.Now;
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("nvarchar(100)");
            configurationBuilder.Properties<Color>().HaveConversion(typeof(ColorToStringConverter));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KpiDbContext).Assembly);
            _modelConfiguration.ConfigureModel(modelBuilder);
            modelBuilder.Entity<Theme>().Navigation(e => e.Measures).AutoInclude();

            //Add a shadow property to all entity types
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (!entityType.IsOwned())
            //        modelBuilder.Entity(entityType.Name).Property<DateTime>("ModifiedOn");
            //}
            
        }
    }

    public class ColorToStringConverter : ValueConverter<Color, string>
    {
        public ColorToStringConverter() : base(ColorString, ColorStruct) { }

        private static Expression<Func<Color, string>> ColorString = v => new String(v.Name);
        private static Expression<Func<string, Color>> ColorStruct = v => Color.FromName(v);

    }
}