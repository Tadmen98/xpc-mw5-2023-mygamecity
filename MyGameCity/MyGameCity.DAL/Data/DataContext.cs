using Microsoft.EntityFrameworkCore;

using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.Data;

public class DataContext : DbContext
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<GameEntity> Game { get; set; }
    public DbSet<ReviewEntity> Review { get; set; }
    public DbSet<DeveloperEntity> Developer { get; set; }
}
