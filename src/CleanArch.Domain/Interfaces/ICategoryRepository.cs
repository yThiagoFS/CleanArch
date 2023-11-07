using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(long? id);

        Task<IEnumerable<Category>> GetAll();

        Task<Category> Add(Category data);

        Task Delete(long? id);

        Task<Category> Update(Category category);
    }
}
