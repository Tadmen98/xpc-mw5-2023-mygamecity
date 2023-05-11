using Microsoft.IdentityModel.Tokens;
using MyGameCity.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.IntegrationTests.Controller_Tests
{
    public class DeveloperControllerTests : IDisposable
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;
        public DeveloperControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task POST_IfDoesntExist_CreateDeveloper()
        {
            var TestDeveloper = new DeveloperDTO
            {
                CountryOfOrigin = "Poland",
                Description = "Action-Adventure game developer",
                Id = Guid.Parse("12463f65-a2d2-4db8-b53a-fee3f02241b4"),
                LogoImg = "meh",
                Title = "Kifuz"
            };

            var response = await _client.PostAsync("/api/Developer", JsonContent.Create(TestDeveloper));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfDoesntExist_CreateGane()
        {
            var TestDeveloper = new DeveloperDTO
            {
                CountryOfOrigin = "USA",
                Description = "RPG game developer",
                Id = Guid.Parse("12463f65-a2d2-4db8-b53a-fee3f02241b4"),
                LogoImg = "meh",
                Title = "Kifuz"
            };

            var response = await _client.PutAsync("/api/Developer/12463f65-a2d2-4db8-b53a-fee3f02241b4", JsonContent.Create(TestDeveloper));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GET_Always_GetAllDevelopers()
        {
            var response = await _client.GetAsync("/api/Developer");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GET_IfIdExists_DeveloperById()
        {
            var response = await _client.GetAsync("/api/Developer/3fa85f64-0717-4562-b3fc-2c963f66afa6");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DELETE_IfIdExists_DeveloperById()
        {
            var response = await _client.DeleteAsync("/api/Developer/12463f65-a2d2-4db8-b53a-fee3f02241b4");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
