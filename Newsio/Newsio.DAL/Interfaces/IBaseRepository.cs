namespace Newsio.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T> DeleteByIdAsync(int id);
    }
}
