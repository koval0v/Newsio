namespace Newsio.BLL.Interfaces
{
    public interface IBaseService<T> where T : IBaseDto
    {
        Task<T> AddAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(int id, T model);
        Task DeleteByIdAsync(int modelId);
    }
}
