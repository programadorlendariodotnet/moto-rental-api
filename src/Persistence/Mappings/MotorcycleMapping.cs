using Domain.Models.MotorcycleAggregate.Entities;
using Domain.Models.MotorcycleAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Persistence.Mappings;

public class MotorcycleMapping : IEntityTypeConfiguration<Motorcycle>
{
    private const string TableName = "Motorcycles";

    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Year)
            .HasColumnType("smallint")
            .IsRequired();

        builder.OwnsOne(x => x.UId)
           .Property(x => x.Value)
           .HasColumnName(nameof(Motorcycle.UId))
           .HasColumnType("varchar")
           .HasMaxLength(UIdValue.FieldMaxLength)
           .IsRequired();

        builder.OwnsOne(x => x.Model)
           .Property(x => x.Value)
           .HasColumnName(nameof(Motorcycle.Model))
           .HasColumnType("varchar")
           .HasMaxLength(ModelValue.FieldMaxLength)
           .IsRequired();

        builder.OwnsOne(x => x.Plate)
           .Property(x => x.Value)
           .HasColumnName(nameof(Motorcycle.Plate))
           .HasColumnType("varchar")
           .HasMaxLength(PlateValue.FieldMaxLength)
           .IsRequired();
    }
}
