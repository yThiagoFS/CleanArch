using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryDto categoryDto, CancellationToken cancellationToken);

        Task DeleteCategoryById(long? id, CancellationToken cancellationToken);

        Task DeleteCategory(CategoryDto categoryDto, CancellationToken cancellationToken);

        Task<IEnumerable<CategoryDto>> GetCategories(CancellationToken cancellationToken);

        Task<CategoryDto> GetCategoryById(long? id, CancellationToken cancellationToken);

        Task<CategoryDto> UpdateCategory(CategoryDto categoryDto, CancellationToken cancellationToken);
    }
}
