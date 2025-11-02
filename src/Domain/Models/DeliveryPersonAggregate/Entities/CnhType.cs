namespace Domain.Models.DeliveryPersonAggregate.Entities;

public sealed class CnhType
{
    public int Id { get; private set; }
    public string Description { get; private set; }

    private CnhType() { }

    public static CnhType Create(Enums.CnhType @enum, string description)
    {
        var cnhType = new CnhType();

        cnhType.SetId((int)@enum);
        cnhType.SetDescription(description);

        return cnhType;
    }

    private void SetId(int id)
    {
        Id = id;
    }

    private void SetDescription(string description)
    {
        Description = description;
    }
}