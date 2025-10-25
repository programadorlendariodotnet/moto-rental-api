using Domain.Models.DeliveryPersonAggregate.Entities;
using Domain.Models.DeliveryPersonAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class DeliveryPersonMapping : IEntityTypeConfiguration<DeliveryPerson>
{
    private const string TableName = "DeliveryPersons";

    public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        builder.OwnsOne(x => x.UId)
           .Property(x => x.Value)
           .HasColumnName(nameof(DeliveryPerson.UId))
           .HasColumnType("varchar")
           .HasMaxLength(UIdValue.FieldMaxLength)
           .IsRequired();

        builder.OwnsOne(x => x.Name)
           .Property(x => x.Value)
           .HasColumnName(nameof(DeliveryPerson.Name))
           .HasColumnType("varchar")
           .HasMaxLength(NameValue.FieldMaxLength)
           .IsRequired();

        builder.OwnsOne(x => x.Cnpj)
           .Property(x => x.Value)
           .HasColumnName(nameof(DeliveryPerson.Cnpj))
           .HasColumnType("varchar")
           .HasMaxLength(CnpjValue.FieldMaxLength)
           .IsRequired();

        builder.OwnsOne(x => x.CnhNumber)
           .Property(x => x.Value)
           .HasColumnName(nameof(DeliveryPerson.CnhNumber))
           .HasColumnType("varchar")
           .HasMaxLength(NumberValue.FieldMaxLength)
           .IsRequired();

        builder.Property(x => x.CnhType)
           .HasColumnName(nameof(DeliveryPerson.CnhType))
            .HasConversion<int>()
            .HasColumnType("smallint")
            .IsRequired();

        builder.OwnsOne(x => x.CnhImageUrl)
          .Property(x => x.Value)
          .HasColumnName(nameof(DeliveryPerson.CnhImageUrl))
          .HasColumnType("varchar")
          .HasMaxLength(ImageUrlValue.FieldMaxLength)
          .IsRequired(false);
    }
}
