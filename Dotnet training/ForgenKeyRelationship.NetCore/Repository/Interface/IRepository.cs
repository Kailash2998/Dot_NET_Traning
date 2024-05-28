namespace ForgenKeyRelationship.NetCore.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAllWithIncludes();
        Task<T> GetByIdAsync(int id);
    }
}
