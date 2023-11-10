using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.Products.Handlers 
{
    public class ProductQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        , IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await this._productRepository.GetById(request.Id);

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await this._productRepository.GetAll();
    }
}