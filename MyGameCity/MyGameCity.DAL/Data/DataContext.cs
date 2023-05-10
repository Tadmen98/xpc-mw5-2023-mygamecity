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
    //public DbSet<ManufacturerEntity> Manufacturer { get; set; }
    public DbSet<ReviewEntity> Review { get; set; }

    public DbSet<DeveloperEntity> Developer { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
    //{
    //    base.OnConfiguring(optionsbuilder);
    //    optionsbuilder.UseSqlServer("server=localhost\\sqlexpress;database=TestDatabase;trusted_connection=true;trustservercertificate=true;");//trustservercertificate=true?
    //}
    //TODO: remove harcoded path
    //TODO: replace with variable databaseName
}
