using Product_Api.Domain.Entities;

namespace Product_Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product product);
    }
}
