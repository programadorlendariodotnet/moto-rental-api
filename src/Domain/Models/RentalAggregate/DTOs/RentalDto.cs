namespace Domain.Models.RentalAggregate.DTOs;

public record RentalDto(
    string UId,
    string DeliveryPersonUId,
    string MotorcycleUId,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? EndDate,
    int Days,
    decimal DailyRate,
    decimal? TotalAmount
);