using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;

namespace Newsio.DAL.Tests
{
    public class RepositoryHelper
    {
        public static DbContextOptions<NewsContext> GetNewsDbOptions()
        {
            var options = new DbContextOptionsBuilder<NewsContext>()
                .UseInMemoryDatabase($"NewsDbTest-{Guid.NewGuid()}")
                .Options;

            using (var context = new NewsContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        private static void SeedData(NewsContext context)
        {
            var users = new List<User>
            {
                new User { UserName = "user1", Password = "user1P" },
                new User { UserName = "user2", Password = "user2P" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var sections = new List<Section>
            {
                    new Section { Title = "Section1" },
                    new Section { Title = "Section2" },
                    new Section { Title = "Section3" }
            };
            context.Sections.AddRange(sections);
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag { Title = "Tag1" },
                new Tag { Title = "Tag2" },
                new Tag { Title = "Tag3" }
            };
            context.Tags.AddRange(tags);
            context.SaveChanges();

            var news = new List<News>
            {
                    new News { Title = "News1", Description = "News1D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 1, AuthorId = 1 },
                    new News { Title = "News2", Description = "News2D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 2, AuthorId = 2 },
                    new News { Title = "News3", Description = "News3D", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, SectionId = 3, AuthorId = 1 }
            };
            context.News.AddRange(news);
            context.SaveChanges();

            var newsTags = new List<NewsTag>
            {
                new NewsTag { NewsId = 1, TagId = 1 },
                new NewsTag { NewsId = 1, TagId = 2 },
                new NewsTag { NewsId = 1, TagId = 3 },
                new NewsTag { NewsId = 2, TagId = 1 },
                new NewsTag { NewsId = 2, TagId = 2 }
            };
            context.NewsTags.AddRange(newsTags);
            context.SaveChanges();
        }
    }
}
