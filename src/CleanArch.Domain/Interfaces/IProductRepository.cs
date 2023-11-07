using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(long? id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Add(Product data);

        Task Delete(long? id);

        Task<Product> Update(Product category);
    }
}
