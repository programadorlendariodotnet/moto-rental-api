using Domain.Models.DeliveryPersonAggregate.Enums;
using Domain.Models.DeliveryPersonAggregate.ValueObjects;
using Domain.Models.Shared.ValueObjects;
using FluentResults;

namespace Domain.Models.DeliveryPersonAggregate.Entities;

public class DeliveryPerson
{
    public int Id { get; private set; }
    public UIdValue UId { get; private set; }
    public NameValue Name { get; private set; }
    public CnpjValue Cnpj { get; private set; }
    public DateTime BirthDate { get; private set; } // Criar value Obj
    public NumberValue CnhNumber { get; private set; }
    public CnhType CnhType { get; private set; } // Criar Enum
    public ImageUrlValue? CnhImageUrl { get; private set; }

    private DeliveryPerson() { }

    public static Result<DeliveryPerson> Create(
        string uId,
        string name,
        string cnpj,
        DateTime birthDate,
        string cnhNumber,
        CnhType cnhType)
    {
        var entity = new DeliveryPerson();

        var result = Result.Merge(
            entity.SetUId(uId),
            entity.SetName(name),
            entity.SetCnpj(cnpj),
            entity.SetBirthDate(birthDate),
            entity.SetCnhNumber(cnhNumber),
            entity.SetCnhType(cnhType)
        );

        if (result.IsFailed)
            return result;

        return Result.Ok(entity);
    }

    private Result SetUId(string uId)
    {
        var creation = UIdValue.Create(uId, GetType().Name.ToLower());
        if (creation.IsFailed)
            return creation.ToResult();

        UId = creation.Value;
        return creation.ToResult();
    }

    private Result SetName(string name)
    {
        var creation = NameValue.Create(name, GetType().Name.ToLower());
        if (creation.IsFailed)
            return creation.ToResult();

        Name = creation.Value;
        return creation.ToResult();
    }

    private Result SetCnpj(string cnpj)
    {
        var creation = CnpjValue.Create(cnpj, GetType().Name.ToLower());
        if (creation.IsFailed)
            return creation.ToResult();

        Cnpj = creation.Value;
        return creation.ToResult();
    }

    private Result SetBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;

        return Result.Ok();
    }

    private Result SetCnhNumber(string number)
    {
        var creation = NumberValue.Create(number, GetType().Name.ToLower());

        if (creation.IsFailed)
            return creation.ToResult();

        CnhNumber = creation.Value;
        return creation.ToResult();
    }

    private Result SetCnhType(CnhType type)
    {
        CnhType = type;

        return Result.Ok();
    }

    public Result UpdateCnhImage(string imageUrl)
    {
        var creation = ImageUrlValue.Create(imageUrl, GetType().Name.ToLower());

        if (creation.IsFailed)
            return creation.ToResult();

        CnhImageUrl = creation.Value;
        return creation.ToResult();
    }
}