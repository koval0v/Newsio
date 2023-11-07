using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Repositories;

namespace Newsio.DAL.Tests
{
    public class NewsRepositoryTests
    {
        #region data
            static List<User> users = new List<User>
            {
                new User { UserName = "user1", Password = "user1P" },
                new User { UserName = "user2", Password = "user2P" }
            };

            static List<Section> sections = new List<Section>
            {
                new Section { Title = "Section1" },
                new Section { Title = "Section2" },
                new Section { Title = "Section3" }
            };

            static List<Tag> tags = new List<Tag>
            {
                new Tag { Title = "Tag1" },
                new Tag { Title = "Tag2" },
                new Tag { Title = "Tag3" }
            };

            static List<News> news = new List<News>
            {
                new News { Title = "News1", Description = "News1D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 1, AuthorId = 1 },
                new News { Title = "News2", Description = "News2D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 2, AuthorId = 2 },
                new News { Title = "News3", Description = "News3D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 3, AuthorId = 1 }
            };

            static List<NewsTag> newsTags = new List<NewsTag>
            {
                new NewsTag { NewsId = 1, TagId = 1 },
                new NewsTag { NewsId = 1, TagId = 2 },
                new NewsTag { NewsId = 1, TagId = 3 },
                new NewsTag { NewsId = 2, TagId = 1 },
                new NewsTag { NewsId = 2, TagId = 2 }
            };
        #endregion

        [Fact]
        public async Task NewsRepository_GetAll_Returns3Values()
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            // Act
            var news = await _newsRepository.GetAllAsync();

            // Assert
            Assert.Equal(3, news.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task NewsRepository_GetByExistingId_ReturnsValue(int newsId)
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            // Act
            var news = await _newsRepository.GetByIdAsync(newsId);

            // Assert
            Assert.Equal(newsId, news.Id);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(100)]
        public async Task NewsRepository_GetByUnexistingId_ThrowsKeyNotFoundException(int newsId)
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            // Act=

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _newsRepository.GetByIdAsync(newsId));
        }


        [Fact]
        public async Task NewsRepository_AddNews_AddedNewsExists()
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            var newsToAdd = new News { Id = 100, Title = "News100", Description = "News100D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 1, AuthorId = 1 };

            // Act
            var addedNews = await _newsRepository.AddAsync(newsToAdd);

            // Assert
            Assert.Equal(newsToAdd.Id, addedNews.Id);
            Assert.Equal(newsToAdd.Title, addedNews.Title);
        }

        [Fact]
        public async Task NewsRepository_UpdateNews_ChangesTitle()
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            var newsToUpdate = new News { Id = 1, Title = "News1UPDATED", Description = "News1D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 1, AuthorId = 1 };

            // Act
            _newsRepository.Update(newsToUpdate);

            var updated = await _newsRepository.GetByIdAsync(newsToUpdate.Id);

            // Assert
            Assert.Equal("News1UPDATED", updated.Title);
        }

        [Fact]
        public async Task NewsRepository_DeleteUnexistingNews_ThrowsKeyNotFoundException()
        {
            // Arrange
            using var context = new NewsContext(RepositoryHelper.GetNewsDbOptions());

            var _newsRepository = new NewsRepository(context);

            // Act

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _newsRepository.DeleteByIdAsync(1000));
        }
    }
}