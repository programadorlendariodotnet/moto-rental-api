using Domain.Models.DeliveryPersonAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Enums = Domain.Models.DeliveryPersonAggregate.Enums;

namespace Persistence.Mappings;

public class CnhTypeMapping : IEntityTypeConfiguration<CnhType>
{
    private const string TableName = "CnhTypes";

    public void Configure(EntityTypeBuilder<CnhType> builder)
    {
        builder.ToTable(TableName);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(CnhType.Description))
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasData(Enum.GetValues(typeof(Enums.CnhType))
            .Cast<Enums.CnhType>()
            .Select(e => CnhType.Create(e, $"{e}")));
    }
}