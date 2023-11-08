using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Product?> GetWithCategoryById(long? id)
            => await this._dbContext.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
    }
}
