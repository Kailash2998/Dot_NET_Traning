using Assign.Net___5.Models;
using Assign.Net___5.Repository;

namespace Assign.Net___5.Services
{
    public class GenericRepository<T> : IRepository<Student> where T : class
    {
        private readonly List<Student> _entities;

        public GenericRepository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            // Assuming T has a property named "Id"
            return _entities.Find(entity => entity.GetType().GetProperty("Id").GetValue(entity).Equals(id));
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            // No need to implement for static data
        }

        public void Delete(int id)
        {
            // Assuming T has a property named "Id"
            var entityToRemove = _entities.Find(entity => entity.GetType().GetProperty("Id").GetValue(entity).Equals(id));
            if (entityToRemove != null)
            {
                _entities.Remove(entityToRemove);
            }
        }
    }
}
