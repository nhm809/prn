using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ProductRepository : BaseRepository<Product>
{
    public async Task<List<Product>> GetProductsWithCategoryAsync()
    {
        return await _dbSet.Include(p => p.Category).ToListAsync();
    }
    

    public async Task<Product?> GetByIdWithCategoryAsync(int id)
    {
        return await _dbSet.Include(p => p.Category)
                           .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task AddProductAsync(Product product)
    {
        await AddAsync(product);
        await SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        Update(product);
        await SaveChangesAsync();
    }

    public async Task RemoveProductAsync(Product product)
    {
        Remove(product);
        await SaveChangesAsync();
    }
}
