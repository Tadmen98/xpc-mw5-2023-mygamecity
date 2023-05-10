using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MyGameCity.IntegrationTests.Controller_Tests
{
    public class ReviewControllerTests
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;
        public ReviewControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [Fact]
        public async Task GET_IfIdExists_ReviewByGameId()
        {
            var response = await _client.GetAsync("/api/Review/bygame/3fa85f64-5717-4392-b3fc-2c963f66afb6");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GET_IfIdExists_GetReviewByID()
        {
            var response = await _client.GetAsync("/api/Review/3fa85f64-0717-4562-b3fc-2c963f66afa7");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
