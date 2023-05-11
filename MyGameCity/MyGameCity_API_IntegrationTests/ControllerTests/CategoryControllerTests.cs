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
    public class CategoryControllerTests : IDisposable
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;
        public CategoryControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }


        [Fact]
        public async Task POST_IfDoesntExist_CreateCategory()
        {
            var TestCategory = new CategoryDTO
            {
                Id = Guid.Parse("0fcd579e-8b64-435f-a306-4afbea773a48"),
                Name = "Adventure"
            };

            var response = await _client.PostAsync("/api/Category", JsonContent.Create(TestCategory));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfExist_UpdateCategory()
        {
            var TestCategory = new CategoryDTO
            {
                Id = Guid.Parse("0fcd579e-8b64-435f-a306-4afbea773a48"),
                Name = "RPG"
            };

            var response = await _client.PutAsync("/api/Category/0fcd579e-8b64-435f-a306-4afbea773a48", JsonContent.Create(TestCategory));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_IfIdExists_CategoryById()
        {
            var response = await _client.GetAsync("/api/Category/6704e2f6-2c6a-47f1-a518-02653a45bc13");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_Always_GetAllCategories()
        {
            var response = await _client.GetAsync("/api/Category");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]

        public async Task Delete_Always_GetAllCategories()
        {
            var response = await _client.DeleteAsync("/api/Category/0fcd579e-8b64-435f-a306-4afbea773a48");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
