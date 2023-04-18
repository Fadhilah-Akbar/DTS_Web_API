using DTS_Web_Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Web_Api.Repository
{
    public class GeneralRepository<TEntity, TKey, TContext> : IGeneralRepository<TEntity, TKey>
    where TEntity : class
    where TContext : MyContext
    {
        protected TContext _context;
        public GeneralRepository(TContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey key)
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public async Task InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey key)
        {
            var entity = await GetByIdAsync(key);
            _context.Set<TEntity>().Remove(entity!);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> IsExist(TKey key)
        {
            var entity = await GetByIdAsync(key);
            return entity != null;
        }
    }
}
