using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyGameCity.IntegrationTests.Controller_Tests
{
    public class ReviewControllerTests :IDisposable
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
            Guid guid = Guid.NewGuid();
            var TestReview = new ReviewDTO
            {
                Description = "Very cool",
                Title = "Nice game",
                Id = guid,
                GameId = Guid.Parse("739bfc28-0b47-41e6-83ce-f3de0e630041"),
                StarsCount = 4
            };
            var response = await _client.PostAsync("/api/Review", JsonContent.Create(TestReview));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfExists_UpdateReview()
        {
            var TestReview = new ReviewDTO
            {
                Description = "Very boring",
                Title = "Meh Game",
                Id = Guid.Parse("14c8d3dd-d776-4a95-b70f-ef645ad9acf2"),
                GameId = Guid.Parse("c67fddba-2f3f-4a84-96f1-02058156864f"),
                StarsCount = 1
            };
            var response = await _client.PutAsync("/api/Review", JsonContent.Create(TestReview));
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
            var response = await _client.GetAsync("/api/Review/93f9ec0d-79f8-4e72-bba7-e8fcd6e10648");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task DELETE_IfIdExists_GetReviewByID()
        {
            var guid = Guid.NewGuid();
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var review_dto = new ReviewDTO
                {
                    Description = "Pretty cool",
                    GameId = Guid.Parse("c67fddba-2f3f-4a84-96f1-02058156864f"),
                    Id = guid,
                    StarsCount = 5,
                    Title = "StarCraft"
                };
                var review = new ReviewEntity(review_dto);
                context.Review.Add(review);
                await context.SaveChangesAsync();
            }
            var response = await _client.DeleteAsync($"/api/Review/{guid}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
