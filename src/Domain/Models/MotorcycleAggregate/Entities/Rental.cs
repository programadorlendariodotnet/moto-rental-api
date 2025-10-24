using Domain.Models.MotorcycleAggregate.ValueObjects.Shared;
using FluentResults;

namespace Domain.Models.MotorcycleAggregate.Entities;

public class Rental
{
    public int Id { get; private set; }
    public UIdValue UId { get; private set; }
    public Guid DeliveryPersonUId { get; private set; }
    public Guid MotorcycleUId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime ExpectedEndDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int Days { get; private set; }
    public decimal DailyRate { get; private set; }
    public decimal? TotalAmount { get; private set; }

    private Rental() { }

    public static Result<Rental> Create(
        string uId,
        Guid deliveryPersonUId,
        Guid motorcycleUId,
        int days,
        decimal dailyRate)
    {
        var rental = new Rental();

        var result = Result.Merge(
            rental.SetUId(uId),
            rental.SetDeliveryPersonUId(deliveryPersonUId),
            rental.SetMotorcycleUId(motorcycleUId),
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


    private Result SetDeliveryPersonUId(Guid id)
    {
        if (id == Guid.Empty)
            return Result.Fail("Invalid delivery person UId.");

        DeliveryPersonUId = id;
        return Result.Ok();
    }

    private Result SetMotorcycleUId(Guid id)
    {
        if (id == Guid.Empty)
            return Result.Fail("Invalid motorcycle UId.");

        MotorcycleUId = id;
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