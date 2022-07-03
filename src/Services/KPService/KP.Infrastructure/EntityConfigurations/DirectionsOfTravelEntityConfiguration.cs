using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.Infrastructure.EntityConfigurations;

internal class DirectionsOfTravelEntityConfiguration: IEntityTypeConfiguration<DirectionsOfTravel>
{
    public void Configure(EntityTypeBuilder<DirectionsOfTravel> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}
internal class KpiTypeEntityConfiguration : IEntityTypeConfiguration<KpiType>
{
    public void Configure(EntityTypeBuilder<KpiType> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}
internal class MeasureTypeEntityConfiguration : IEntityTypeConfiguration<MeasureType>
{
    public void Configure(EntityTypeBuilder<MeasureType> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}
internal class StatusEntityConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}
internal class UnitsOfMeasureEntityConfiguration : IEntityTypeConfiguration<UnitsOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitsOfMeasure> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}
internal class MeasureEntityConfiguration : IEntityTypeConfiguration<Measure>
{
    public void Configure(EntityTypeBuilder<Measure> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
        builder.HasOne(d => d.KpiType)
            .WithMany(p => p.Measures)
            .HasForeignKey(d => d.KpiTypeId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict)
            .HasConstraintName("FK_KPIType_KPITypeId");
        builder.HasOne(d => d.Theme)
            .WithMany(p => p.Measures)
            .HasForeignKey(d => d.ThemeId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Theme_ThemeId");

        builder.HasOne(d => d.UnitsOfMeasure)
            .WithMany(p => p.Measures)
            .HasForeignKey(d => d.UnitsOfMeasureId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Measure_UnitsOfMeasureId");

    }
}

internal class ThemeEntityConfiguration : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
    }
}

internal class KpiEntityConfiguration : IEntityTypeConfiguration<Kpi>
{
    public void Configure(EntityTypeBuilder<Kpi> builder)
    {
        builder.Property(e => e.ActualClosingPositionEndDate).HasColumnType("date");

        builder.Property(e => e.ActualClosingPositionStartDate).HasColumnType("date");

        builder.Property(e => e.ActualYtdCurrent).HasColumnName("ActualYTDCurrent");

        builder.Property(e => e.ActualYtdPrevious).HasColumnName("ActualYTDPrevious");

        builder.Property(e => e.CreatedOn).HasColumnType("datetime");

        builder.Property(e => e.ForecastDate).HasColumnType("date");

        builder.Property(e => e.ForecastValue).HasMaxLength(50);

        builder.Property(e => e.Lead).HasMaxLength(5);

        builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

        builder.Property(e => e.TargetDate).HasColumnType("date");

        builder.Property(e => e.TargetValue).HasMaxLength(50);

        builder.HasOne(d => d.DirectionsOfTravel)
            .WithMany(p => p.Kpis)
            .HasForeignKey(d => d.DirectionsOfTravelId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_DirectionsOfTravel_DirectionsOfTravelId");

        builder.HasOne(d => d.Measure)
            .WithMany(p => p.Kpis)
            .HasForeignKey(d => d.MeasureId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Measure_MeasureId");

        builder.HasOne(d => d.Status)
            .WithMany(p => p.Kpis)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Status_StatusId");

        builder.HasOne(d => d.UnitsOfMeasure)
            .WithMany(p => p.Kpis)
            .HasForeignKey(d => d.UnitsOfMeasureId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_UnitsOfMeasure_UnitsOfMeasureId");
    }
}