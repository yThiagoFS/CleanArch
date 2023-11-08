namespace CleanArch.Domain.Repositories
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(long? id);

        Task Add(T entity);

        Task<T> Update(T entity);

        Task Delete(long? id);

        Task Delete(T entity);
    }
}
