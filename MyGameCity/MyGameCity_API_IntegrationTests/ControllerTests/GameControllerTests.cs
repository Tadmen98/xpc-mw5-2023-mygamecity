using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.IntegrationTests.Controller_Tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity_API_IntegrationTests.Controller_Tests
{
    public class GameControllerTests : IDisposable
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        public GameControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task POST_IfDoesntExist_CreateGame()
        {
            Guid guid = Guid.NewGuid();
            var TestGame = new GameDTO
            {
                CategoryIds = new List<Guid> { Guid.Parse("739bfc28-0b47-41e6-83ce-f3de0e630041"), Guid.Parse("07136703-0204-4e55-bcc9-3c5b2a6411b8") },
                Description = "Amazing visuals",
                DeveloperId = Guid.Parse("3fa85f64-0717-4562-b3fc-2c963f66afa6"),
                Id = guid,
                ImagePath = "string",
                NumberInStock = 25,
                Price = 60,
                Title = "Infinimanier",
                Weight = 1
            };

            var response = await _client.PostAsync("/api/Game", JsonContent.Create(TestGame));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_Always_GetAllGames()
        {
            var response = await _client.GetAsync("/api/Game/all");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfExists_UpdateGame()
        {
            var TestGame = new GameDTO
            {
                CategoryIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                Description = "Boring",
                DeveloperId = Guid.NewGuid(),
                Id = Guid.Parse("739bfc28-0b47-41e6-83ce-f3de0e630041"),
                ImagePath = "string",
                NumberInStock = 25,
                Price = 60,
                Title = "Infinimanier",
                Weight = 1
            };
            var response = await _client.PutAsync("/api/Game", JsonContent.Create(TestGame));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_IfIdExists_GameById()
        {
            var response = await _client.GetAsync("/api/Game/c67fddba-2f3f-4a84-96f1-02058156864f");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DELETE_IfExists_DeleteGame()
        {
            var guid = Guid.NewGuid();
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var game_dto = new GameDTO
                {
                    CategoryIds = new List<Guid> { Guid.Parse("6704e2f6-2c6a-47f1-a518-02653a45bc13"), Guid.Parse("b82637b8-f931-4a82-be4f-d2dde6660128") },
                    Description = "Just alright",
                    DeveloperId = Guid.Parse("2cd997cf-46c1-43a1-8963-d1e67abfc295"),
                    Id = guid,
                    ImagePath = "string",
                    NumberInStock = 25,
                    Price = 30,
                    Title = "CoolMiner",
                    Weight = 2
                };
                var game = new GameEntity(game_dto);
                context.Game.Add(game);
                await context.SaveChangesAsync();
            }
            var response = await _client.DeleteAsync($"/api/Game/{guid}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
