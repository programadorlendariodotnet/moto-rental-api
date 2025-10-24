using Domain.Models.MotorcycleAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using FluentResults;

namespace Domain.Models.MotorcycleAggregate.Entities;

public class Motorcycle
{
    public int Id { get; private set; }
    public UIdValue UId { get; private set; }
    public int Year { get; private set; }
    public ModelValue Model { get; private set; }
    public PlateValue Plate { get; private set; }

    private Motorcycle() { }

    public static Result<Motorcycle> Create(string uId, int year, string model, string plate)
    {
        var motorcycle = new Motorcycle();

        var result = Result.Merge(
            motorcycle.SetUId(uId),
            motorcycle.SetYear(year),
            motorcycle.SetModel(model),
            motorcycle.SetPlate(plate)
        );

        if (result.IsFailed)
            return result;

        return Result.Ok(motorcycle);
    }

    private Result SetYear(int year)
    {
        Year = year;

        return Result.Ok();
    }

    private Result SetModel(string model)
    {
        var creation = ModelValue.Create(model, GetType().Name.ToLower());

        if (creation.IsFailed)
            return creation.ToResult();

        Model = creation.Value;

        return creation.ToResult();
    }

    private Result SetPlate(string plate)
    {
        var creation = PlateValue.Create(plate, GetType().Name.ToLower());

        if (creation.IsFailed)
            return creation.ToResult();

        Plate = creation.Value;

        return creation.ToResult();
    }

    private Result SetUId(string uId)
    {
        var creation = UIdValue.Create(uId, GetType().Name.ToLower());

        if (creation.IsFailed)
            return creation.ToResult();

        UId = creation.Value;

        return creation.ToResult();
    }
}