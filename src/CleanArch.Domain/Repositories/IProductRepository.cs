using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetWithCategoryById(long? id);
    }
}
