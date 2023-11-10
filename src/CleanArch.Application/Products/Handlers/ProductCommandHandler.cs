using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.Products.Handlers 
{
    public class ProductCommandHandler  : IRequestHandler<ProductCreateCommand, Product>
        , IRequestHandler<ProductRemoveCommand, Product>              
        , IRequestHandler<ProductUpdateCommand, Product> 
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken) 
        {
            var product = new Product(request.Id, request.Name, request.Description, request.Price, request.Stock, request.Image)
            {
                CategoryId = request.CategoryId
            };

            await this._productRepository.Add(product);

            return product;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await this._productRepository.GetById(request.Id);

            if(product is null)
                return null!;

            await this._productRepository.Delete(product);

            return product;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await this._productRepository.GetById(request.Id);

            if(product is null)
                return null!;

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            await this._productRepository.Update(product);

            return product;
        }
    }
}