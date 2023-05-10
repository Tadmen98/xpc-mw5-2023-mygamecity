using MyGameCity.DAL.Entities;
using MyGameCity.IntegrationTests.Controller_Tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task GET_IfIdExists_GameById()
        {
            var response = await _client.GetAsync("/api/Game/3fa85f64-5717-4562-b3fc-2c963f66afb6");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_Always_GetAllGames()
        {
            var response = await _client.GetAsync("/api/Game");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //var data = JsonConvert.DeserializeObject<IEnumerable<GameEntity>>(await response.Content.ReadAsStringAsync());

            //Assert.Collection((data as IEnumerable<GameEntity>)!,
            //    r =>
            //    {
            //        Assert.Equal("3fa85f64-5717-4562-b3fc-2c963f66afb6", r.Id);
            //        Assert.Equal("string", r.ImagePath);
            //    }



            //    );
        }


        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
