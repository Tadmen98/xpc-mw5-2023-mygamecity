using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        public async Task POST_IfDoesntExist_CreateGane()
        {
            var TestGame = new GameDTO
            {
                CategoryIds = new List<Guid> { Guid.Parse("739bfc28-0b47-41e6-83ce-f3de0e630041"), Guid.NewGuid(), Guid.NewGuid() },
                Description = "Amazing visuals",
                DeveloperId = Guid.Parse("3fa85f64-0717-4562-b3fc-2c963f66afa6"),
                Id = Guid.Parse("aa7d9060-4df4-44ec-b86e-767568c432fc"),
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
            var response = await _client.GetAsync("/api/Game");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfExists_UpdateGame()
        {
            var TestGame = new GameDTO{
                CategoryIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                Description = "Boring",
                DeveloperId = Guid.NewGuid(),
                Id = Guid.Parse("aa7d9060-4df4-44ec-b86e-767568c432fc"),
                ImagePath = "string",
                NumberInStock = 25,
                Price = 60,
                Title = "Infinimanier",
                Weight = 1 };
            var response = await _client.PutAsync("/api/Game/aa7d9060-4df4-44ec-b86e-767568c432fc", JsonContent.Create(TestGame));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_IfIdExists_GameById()
        {
            var response = await _client.GetAsync("/api/Game/aa7d9060-4df4-44ec-b86e-767568c432fc");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DELETE_IfExists_DeleteGame()
        {
            var response = await _client.DeleteAsync("/api/Game/aa7d9060-4df4-44ec-b86e-767568c432fc");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
