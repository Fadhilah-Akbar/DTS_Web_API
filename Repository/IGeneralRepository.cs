namespace DTS_Web_Api.Repository
{
    public interface IGeneralRepository<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey key);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
        Task<bool> IsExist(TKey key);
    }
}
