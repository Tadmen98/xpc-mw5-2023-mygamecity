using Microsoft.EntityFrameworkCore;

using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.Data;

public class GamesDbContext : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ComodityEntity> Comodity { get; set; }
    public DbSet<ManufacturerEntity> Manufacturer { get; set; }
    public DbSet<ReviewEntity> Review { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\TAD\\Desktop\\VUT\\10 semestr\\XPC-MW5\\xpc-mw5-2023-mygamecity\\MyGameCity\\MyGameCity.DAL\\Database\\games.db");
    }
    //TODO: remove harcoded path
    //TODO: replace with variable databaseName
}
