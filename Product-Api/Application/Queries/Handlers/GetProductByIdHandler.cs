using MediatR;
using Product_Api.Domain.Entities;
using Product_Api.Domain.Repositories;

namespace Product_Api.Application.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductById(request.Id);
        }
    }
}
