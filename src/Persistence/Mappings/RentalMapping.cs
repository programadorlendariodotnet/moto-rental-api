using Domain.Models.DeliveryPersonAggregate.Entities;
using Domain.Models.MotorcycleAggregate.Entities;
using Domain.Models.RentalAggregate.Entities;
using Domain.Models.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class RentalMapping : IEntityTypeConfiguration<Rental>
{
    private const string TableName = "Rentals";

    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.UId)
           .Property(x => x.Value)
           .HasColumnName(nameof(Rental.UId))
           .HasColumnType("varchar")
           .HasMaxLength(UIdValue.FieldMaxLength)
           .IsRequired();

        builder
            .Property(x => x.DeliveryPersonId)
            .IsRequired();

        builder
            .Property(x => x.MotorcycleId)
            .IsRequired();

        builder
            .Property(x => x.StartDate)
            .HasColumnType("date")
            .IsRequired();

        builder
            .Property(x => x.ExpectedEndDate)
            .HasColumnType("date")
            .IsRequired();

        builder
            .Property(x => x.EndDate)
            .HasColumnType("date")
            .IsRequired(false);

        builder
            .Property(x => x.Days)
            .HasColumnType("smallint")
            .IsRequired();

        builder
            .Property(x => x.DailyRate)
            .HasColumnType("numeric(10,2)")
            .IsRequired();

        builder
            .Property(x => x.TotalAmount)
            .HasColumnType("numeric(10,2)")
            .IsRequired(false);

        builder.HasOne<DeliveryPerson>()
            .WithMany()
            .HasForeignKey(x => x.DeliveryPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Motorcycle>()
            .WithMany()
            .HasForeignKey(x => x.MotorcycleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}