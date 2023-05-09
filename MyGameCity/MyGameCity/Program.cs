
using Microsoft.AspNetCore.HttpLogging;
using MyGameCity.DAL.Data;
using MyGameCity.Services.CatService;
using MyGameCity.Services.DevService;
using MyGameCity.Services.GameService;
using MyGameCity.Services.RevService;

namespace MyGameCity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDeveloperService, DeveloperService>();
            builder.Services.AddScoped<IGameService, GameService>();    
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddDbContext<DataContext>();

            var app = builder.Build();

            app.UseHttpLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}