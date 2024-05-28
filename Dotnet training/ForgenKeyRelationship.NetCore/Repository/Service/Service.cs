using Microsoft.EntityFrameworkCore;
using ForgenKeyRelationship.NetCore.Repository.Interface;
using ForgenKeyRelationship.NetCore.Data;
using ForgenKeyRelationship.NetCore.Models;

namespace ForgenKeyRelationship.NetCore.Repository.Service
{
    /// <summary>
    /// Create Constructor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Service<T> : IRepository<T> where T : class
    {
        private readonly BookManagementContext _context;
        private readonly DbSet<T> _dbSet;

        public Service(BookManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Get the all data from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> GetAll()
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
        /// get data form the database for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetById(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found.");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity with id {id}.", ex);
            }
        }

        /// <summary>
        /// For create the data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> Create(T entity)
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
        /// for update the data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Update(T entity)
        {
            try
            {
                _context.Update(entity); 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        /// <summary>
        /// for delete the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Delete(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found.");
                }

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity with id {id}.", ex);
            }
        }

        /// <summary>
        /// get the list of book from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> GetAllWithIncludes()
        {
            try
            {
                return await _dbSet.Include(b => (b as Book).Author)
                                   .Include(b => (b as Book).Publisher)
                                   .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all entities.", ex);
            }
        }

        /// <summary>
        /// for get the edit of book 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found.");
                }

                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity with id {id}.", ex);
            }
        }
    }
}

