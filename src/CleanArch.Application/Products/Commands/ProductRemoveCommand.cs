using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands 
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public ProductRemoveCommand(long id)
        {
            this.Id = id;
        }

        public long Id { get; set; }
    }
}