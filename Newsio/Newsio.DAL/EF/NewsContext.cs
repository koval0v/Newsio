using Microsoft.EntityFrameworkCore;
using Newsio.DAL.Entities;

namespace Newsio.DAL.EF
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; private set; }
        public DbSet<NewsTag> NewsTags { get; private set; }
        public DbSet<Section> Sections { get; private set; }
        public DbSet<Tag> Tags { get; private set; }
        public DbSet<User> Users { get; private set; }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var news = modelBuilder.Entity<News>();
            news.Property(x => x.Title).IsRequired().HasMaxLength(100);
            news.Property(x => x.Description).IsRequired().HasMaxLength(500);
            news.Property(x => x.CreatedDate).IsRequired();
            news.Property(x => x.UpdatedDate).IsRequired();
            news.Property(x => x.AuthorId).IsRequired();
            news.Property(x => x.SectionId).IsRequired();

            var newsTag = modelBuilder.Entity<NewsTag>();
            newsTag.Property(x => x.TagId).IsRequired();
            newsTag.Property(x => x.NewsId).IsRequired();

            var section = modelBuilder.Entity<Section>();
            section.Property(x => x.Title).IsRequired();

            var tag = modelBuilder.Entity<Tag>();
            tag.Property(x => x.Title).IsRequired();

            var user = modelBuilder.Entity<User>();
            user.Property(x => x.UserName).IsRequired();
            user.Property(x => x.Password).IsRequired();

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().HasData(
                    new Section { Id = 1, Title = "Health" },
                    new Section { Id = 2, Title = "Business" },
                    new Section { Id = 3, Title = "Entertainment & Arts" });

            modelBuilder.Entity<Tag>().HasData(
                    new Tag { Id = 1, Title = "IT" },
                    new Tag { Id = 2, Title = "Coronavirus" },
                    new Tag { Id = 3, Title = "Grammy Awards" });
        }
    }
}
