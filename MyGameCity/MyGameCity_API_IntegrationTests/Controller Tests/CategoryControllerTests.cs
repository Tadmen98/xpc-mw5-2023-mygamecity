using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task GET_IfIdExists_GameById()
        {
            var response = await _client.GetAsync("/api/Category/3fa85f64-5017-4562-b3fc-2c963f66afa6");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_Always_GetAllCategories()
        {
            var response = await _client.GetAsync("/api/Category");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose(); 
        }
    }
}
