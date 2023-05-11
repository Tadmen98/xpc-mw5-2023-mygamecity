
using Microsoft.AspNetCore.HttpLogging;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects;
using MyGameCity.DAL.QueryObjects.Filters;
using MyGameCity.DAL.Services.CatService;
using MyGameCity.DAL.Services.DevService;
using MyGameCity.DAL.Services.GameService;
using MyGameCity.DAL.Services.RevService;

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

            builder.Services.AddScoped<GetGamesFilterQuery>();
            builder.Services.AddScoped<GetDeveloperFilterQuery>();
            builder.Services.AddScoped<GetReviewFilterQuery>();

            //builder.Services.AddScoped<IQuery<GameEntity, GameFilter>, GetGamesFilterQuery>();
            //builder.Services.AddScoped<IQuery<DeveloperEntity, DeveloperFilter>, GetDeveloperFilterQuery>();
            //builder.Services.AddScoped<IQuery<ReviewEntity, ReviewFilter>, GetReviewFilterQuery>();

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