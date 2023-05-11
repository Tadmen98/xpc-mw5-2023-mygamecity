using MyGameCity.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
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
        public async Task POST_IfDoesntExist_CreateReview()
        {
            var TestReview = new ReviewDTO
            {
                Description = "Very cool",
                Title = "Nice game",
                Id = Guid.Parse("a34605f2-b789-4d80-a45a-beed13de19a5"),
                GameId = Guid.Parse("739bfc28-0b47-41e6-83ce-f3de0e630041"),
                StarsCount = 4
            };

            var response = await _client.PostAsync("/api/Review", JsonContent.Create(TestReview));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfDoesntExist_CreateReview()
        {
            var TestReview = new ReviewDTO
            {
                Description = "Very boring",
                Title = "Meh Game",
                Id = Guid.Parse("51bdb679-b86e-4a4c-ab72-21d96ed0ec35"),
                GameId = Guid.Parse("c67fddba-2f3f-4a84-96f1-02058156864f"),
                StarsCount = 1
            };

            var response = await _client.PutAsync("/api/Review/{id}", JsonContent.Create(TestReview));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
            var response = await _client.GetAsync("/api/Review/c67fddba-2f3f-4a84-96f1-02058156864f");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task DELETE_IfIdExists_GetReviewByID()
        {
            var response = await _client.DeleteAsync("/api/Review/51bdb679-b86e-4a4c-ab72-21d96ed0ec35");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
