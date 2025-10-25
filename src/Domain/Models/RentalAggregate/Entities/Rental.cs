using Domain.Models.Shared.ValueObjects;
using FluentResults;

namespace Domain.Models.RentalAggregate.Entities;

public class Rental
{
    public int Id { get; private set; }
    public UIdValue UId { get; private set; }
    public int DeliveryPersonId { get; private set; }
    public int MotorcycleId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime ExpectedEndDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int Days { get; private set; }
    public decimal DailyRate { get; private set; }
    public decimal? TotalAmount { get; private set; }

    private Rental() { }

    public static Result<Rental> Create(
        string uId,
        int deliveryPersonId,
        int motorcycleId,
        int days,
        decimal dailyRate)
    {
        var rental = new Rental();

        var result = Result.Merge(
            rental.SetUId(uId),
            rental.SetDeliveryPersonId(deliveryPersonId),
            rental.SetMotorcycleId(motorcycleId),
            rental.SetDays(days),
            rental.SetDailyRate(dailyRate),
            rental.SetStartAndExpectedDates(days)
        );

        if (result.IsFailed)
            return result;

        return Result.Ok(rental);
    }

    private Result SetUId(string uId)
    {
        var creation = UIdValue.Create(uId, GetType().Name.ToLower());
        if (creation.IsFailed)
            return creation.ToResult();

        UId = creation.Value;
        return creation.ToResult();
    }


    private Result SetDeliveryPersonId(int id)
    {
        if (id == 0)
            return Result.Fail("Invalid delivery person Id.");

        DeliveryPersonId = id;

        return Result.Ok();
    }

    private Result SetMotorcycleId(int id)
    {
        if (id == 0)
            return Result.Fail("Invalid motorcycle Id.");

        MotorcycleId = id;

        return Result.Ok();
    }

    private Result SetDays(int days)
    {
        if (days <= 0)
            return Result.Fail("Days must be greater than zero.");

        Days = days;
        return Result.Ok();
    }

    private Result SetDailyRate(decimal dailyRate)
    {
        if (dailyRate <= 0)
            return Result.Fail("Daily rate must be greater than zero.");

        DailyRate = dailyRate;
        return Result.Ok();
    }

    private Result SetStartAndExpectedDates(int days)
    {
        var start = DateTime.UtcNow.Date.AddDays(1);
        var expectedEnd = start.AddDays(days);

        StartDate = start;
        ExpectedEndDate = expectedEnd;

        return Result.Ok();
    }

    public Result Finalize(DateTime returnDate)
    {
        if (returnDate < StartDate)
            return Result.Fail("Return date cannot be before the start date.");

        EndDate = returnDate;

        var usedDays = (returnDate.Date - StartDate).Days;
        if (usedDays <= 0)
            usedDays = 1;

        TotalAmount = usedDays * DailyRate;

        return Result.Ok();
    }
}