using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries 
{
    public class GetProductByIdQuery : IRequest<Product> 
    {
        public GetProductByIdQuery(long id)
            => this.Id = id;
            
        public long Id { get; set; }
    }
}