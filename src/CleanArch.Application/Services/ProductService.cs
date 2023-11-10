using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(
            IMapper mapper
            , IMediator mediator )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddProduct(ProductDto productDto, CancellationToken cancellationToken)
            =>  await _mediator.Send(_mapper.Map<ProductCreateCommand>(productDto));
            // try
            // {
            //     await _productRepository.Add(product);

            //     await _unitOfWork.Commit();
            // }
            // catch (Exception ex)
            // {
            //     await _unitOfWork.Rollback();

            //     throw new Exception(ex.Message);
            // }

        public async Task DeleteProduct(ProductDto productDto, CancellationToken cancellationToken)
            =>
            //Realizar o delete através do Product Dto -- CORRIGIR
             await _mediator.Send(new ProductRemoveCommand(productDto.Id));
            // var product = _mapper.Map<Product>(productDto);

            // await DeleteProduct(product, cancellationToken);

        public async Task DeleteProductById(long? id, CancellationToken cancellationToken)
            => await _mediator.Send(new ProductRemoveCommand((long)id));

        public async Task<ProductDto> GetProductById(long? id, CancellationToken cancellationToken)
            => _mapper.Map<ProductDto>(await _mediator.Send(new GetProductByIdQuery((long)id)));
            // var product = await _productRepository.GetById(id);

            // return _mapper.Map<ProductDto>(product);

        public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _mediator.Send(new GetProductsQuery()));
            // var products = await _productRepository.GetAll();

            // return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetWithCategoryById(long? id, CancellationToken cancellationToken)
        {
            //Não está retornando com categorias -- CORRIGIR
            return _mapper.Map<ProductDto>(await _mediator.Send(new GetProductByIdQuery((long)id)));

            // var product = await _productRepository.GetWithCategoryById(id);

            // return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto, CancellationToken cancellationToken)
            => _mapper.Map<ProductDto>(await _mediator.Send(_mapper.Map<ProductUpdateCommand>(productDto)));

            // var product = _mapper.Map<Product>(productDto);

            // try
            // {
            //     var productUpdated = await _productRepository.Update(product);

            //     await _unitOfWork.Commit();

            //     return _mapper.Map<ProductDto>(productUpdated);
            // }
            // catch (Exception ex)
            // {
            //     await _unitOfWork.Rollback();

            //     throw new Exception(ex.Message);
            // }

        // private async Task DeleteProduct(Product product, CancellationToken cancellationToken)
        // {
        //     try
        //     {
        //         await _productRepository.Delete(product);

        //         await _unitOfWork.Commit();
        //     }
        //     catch (Exception ex)
        //     {
        //         await _unitOfWork.Rollback();

        //         throw new Exception(ex.Message);
        //     }
        // }
    }
}
