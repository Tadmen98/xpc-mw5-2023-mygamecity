namespace MyGameCity.DAL.Entities;

public abstract record class EntityBase : IEntity
{
    public Guid Id { get; set; }
}
