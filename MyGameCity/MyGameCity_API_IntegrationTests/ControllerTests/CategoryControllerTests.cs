using Microsoft.Extensions.DependencyInjection;
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

namespace MyGameCity.IntegrationTests.Controller_Tests
{
    [Collection("TestCollection")]
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
            Guid guid = Guid.NewGuid();
            var TestCategory = new CategoryDTO
            {
                Id = guid,
                Name = "Puzzle"
            };
            var response = await _client.PostAsync("/api/Category", JsonContent.Create(TestCategory));
            //using (var scope = _factory.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            //    var category_dto = new CategoryDTO
            //    {
            //        Id = guid,
            //        Name = "Puzzle"
            //    };
            //    var category = new CategoryEntity(category_dto);
            //    context.Categories.Remove(category);
            //    await context.SaveChangesAsync();
            //}
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PUT_IfExist_UpdateCategory()
        {
            var TestCategory = new CategoryDTO
            {
                Id = Guid.Parse("6c14d3d0-26f7-4349-891c-caf9c1e5b42f"),
                Name = "RPG"
            };
            var response = await _client.PutAsync("/api/Category", JsonContent.Create(TestCategory));
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
            var guid = Guid.NewGuid();
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var category_dto = new CategoryDTO
                {
                    Id = guid,
                    Name = "RPG"
                };
                var category = new CategoryEntity(category_dto);
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
                var response = await _client.DeleteAsync($"/api/Category/{guid}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
