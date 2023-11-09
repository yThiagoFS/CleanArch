using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.UnitOfWork;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository
            , IMapper mapper
            , IUnitOfWork unitOfWork )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProduct(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productDto);

            try
            {
                await _productRepository.Add(product);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteProduct(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productDto);

            await DeleteProduct(product, cancellationToken);
        }

        public async Task DeleteProductById(long? id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(id);

            await DeleteProduct(product, cancellationToken);
        }

        public async Task<ProductDto> GetProductById(long? id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetWithCategoryById(long? id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetWithCategoryById(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productDto);

            try
            {
                var productUpdated = await _productRepository.Update(product);

                await _unitOfWork.Commit();

                return _mapper.Map<ProductDto>(productUpdated);
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }

        private async Task DeleteProduct(Product product, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.Delete(product);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }
    }
}
