using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Products
{
    internal class ProductRepository(AppDbContext context)
        : GenericRepository<Product, int>(context), IProductRepository
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
            return Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
        }
    }
}