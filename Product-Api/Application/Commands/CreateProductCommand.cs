using Product_Api.Domain.Entities;
using MediatR;

namespace Product_Api.Application.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
    }
}
