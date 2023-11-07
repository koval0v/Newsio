using AutoMapper;
using Moq;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.BLL.Services;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;
using Newsio.DAL.Repositories;
using Newsio.DAL.Tests;

namespace Newsio.BLL.Tests
{
    public class NewsServiceTests
    {

        [Fact]
        public async Task NewsService_WhenAddNews_ThenAddedNewsIsEqual()
        {
            // Arrange
            var data = new ServiceHelper();

            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var service = new NewsService(new EFUnitOfWork(context), data.CreateMapperProfile());

            var news = new NewsDto()
            {
                Id = 101,
                Title = "Git",
                Description = "GIT",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                AuthorId = 1,
                SectionId = 2
            };

            // Act
            await service.AddAsync(news);

            var added = await service.GetByIdAsync(news.Id);

            // Assert
            Assert.Equal(news.Id, added.Id);
            Assert.Equal(news.Title, added.Title);
        }

        [Fact]
        public async Task NewsService_WhenAddNewsAndThenDelete_ThenThrowsKeyNotFoundException()
        {
            // Arrange
            var data = new ServiceHelper();

            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var service = new NewsService(new EFUnitOfWork(context), data.CreateMapperProfile());

            var news = new NewsDto()
            {
                Id = 101,
                Title = "Git",
                Description = "GIT",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                AuthorId = 1,
                SectionId = 2
            };

            // Act
            await service.AddAsync(news);

            await service.DeleteByIdAsync(news.Id);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetByIdAsync(news.Id));
        }
    }
}