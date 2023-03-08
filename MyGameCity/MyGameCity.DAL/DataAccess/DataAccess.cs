using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.Migrations;

namespace MyGameCity.DAL.DataAccess;

public class DataAccess
{
    GamesDbContext context = new();

    public void AddDbEntry<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        this.context.Add(entity);
    }

    public void RemoveEntry<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        this.context.Remove(entity);
    }

    public void SaveChanges() => this.context.SaveChanges(); 
}
