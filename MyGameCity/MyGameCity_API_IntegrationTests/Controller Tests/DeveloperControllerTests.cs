using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
