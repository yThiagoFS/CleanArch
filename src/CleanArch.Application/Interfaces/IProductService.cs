using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductDto productDto, CancellationToken cancellationToken);

        Task DeleteProductById(long? id, CancellationToken cancellationToken);

        Task DeleteProduct(ProductDto productDto, CancellationToken cancellationToken);

        Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken);

        Task<ProductDto> GetProductById(long? id, CancellationToken cancellationToken);

        Task<Product?> GetWithCategoryById(long? id, CancellationToken cancellationToken);

        Task<ProductDto> UpdateProduct(ProductDto productDto, CancellationToken cancellationToken);
    }
}
