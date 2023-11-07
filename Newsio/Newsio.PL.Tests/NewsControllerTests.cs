using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newsio.DAL.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Newsio.PL.Tests
{
    public class NewsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        readonly HttpClient _client;

        public NewsControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateNews_WhenExistingNews_ThanResponseCode400()
        {
            // Arrange
            News newsTemp = new News()
            {
                Id = 101,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                AuthorId = 1,
                SectionId = 1,
                Title = "News",
                Description = "NewNewNewNewNewNew"
            };
            string json = JsonConvert.SerializeObject(newsTemp);

            // Act
            await _client.PostAsync("api/news", new StringContent(json, Encoding.UTF8, "application/json"));
            var htppResponse = await _client.PostAsync("api/news", new StringContent(json, Encoding.UTF8, "application/json"));

            await _client.DeleteAsync($"api/news/{newsTemp.Id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, htppResponse.StatusCode);
        }
    }
}