using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private NewsContext _db;
        private NewsRepository _newsRepository;
        private NewsTagRepository _newsTagRepository;
        private SectionRepository _sectionRepository;
        private TagRepository _tagRepository;
        private UserRepository _userRepository;

        public EFUnitOfWork(NewsContext dbContext)
        {
            _db = dbContext;
        }

        public INewsRepository News
        {
            get
            {
                if (_newsRepository == null)
                    _newsRepository = new NewsRepository(_db);
                return _newsRepository;
            }
        }

        public INewsTagRepository NewsTags
        {
            get
            {
                if (_newsTagRepository == null)
                    _newsTagRepository = new NewsTagRepository(_db);
                return _newsTagRepository;
            }
        }

        public IBaseRepository<Section> Sections
        {
            get
            {
                if (_sectionRepository == null)
                    _sectionRepository = new SectionRepository(_db);
                return _sectionRepository;
            }
        }

        public IBaseRepository<Tag> Tags
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_db);
                return _tagRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
