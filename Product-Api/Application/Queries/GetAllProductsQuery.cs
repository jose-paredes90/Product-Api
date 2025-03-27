using MediatR;
using Product_Api.Domain.Entities;

namespace Product_Api.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
