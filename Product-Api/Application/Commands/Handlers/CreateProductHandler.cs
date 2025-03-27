using MediatR;
using Product_Api.Domain.Entities;
using Product_Api.Domain.Repositories;

namespace Product_Api.Application.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Category = request.Category,
                CreatedAt = DateTime.Now
            };
            product.Id = await _repository.AddProduct(product);
            return product;
        }
    }
}
