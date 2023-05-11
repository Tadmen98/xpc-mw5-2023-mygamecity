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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master4;Trusted_Connection=True;TrustServerCertificate=True;");//TrustServerCertificate=true?
    }
    //TODO: remove harcoded path
    //TODO: replace with variable databaseName
}
