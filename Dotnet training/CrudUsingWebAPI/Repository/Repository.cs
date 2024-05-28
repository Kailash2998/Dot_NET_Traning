using CrudUsingWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingWebAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// To get the list of the list of Product
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all entities.", ex);
            }
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity with id {id}.", ex);
            }
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the entity.", ex);
            }
        }

        /// <summary>
        /// Update product by id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity with id {id}.", ex);
            }
        }
    }
}
