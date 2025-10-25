namespace Domain.Models.DeliveryPersonAggregate.DTOs;

public record DeliveryPersonDto(
    string UId,
    string Name,
    string Cnpj,
    DateTime BirthDate,
    string CnhNumber,
    string CnhType,
    string? CnhImageUrl
);