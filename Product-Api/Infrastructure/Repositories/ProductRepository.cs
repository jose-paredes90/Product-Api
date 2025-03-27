using Product_Api.Domain.Entities;
using Product_Api.Domain.Repositories;
using Product_Api.Infrastructure.DataContext;
using Dapper;

namespace Product_Api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            const string sql = "SELECT Id, Name, Price, Stock, Category, CreatedAt FROM Products ORDER BY CreatedAt DESC";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Product>(sql);
        }

        public async Task<Product> GetProductById(int id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(
                "SELECT * FROM Products WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> AddProduct(Product product)
        {
            const string sql = @"
            INSERT INTO Products (Name, Price, Stock, Category, CreatedAt) 
            VALUES (@Name, @Price, @Stock, @Category, GETDATE());
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, product);
        }
    }
}
