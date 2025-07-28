using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ProductRepository : BaseRepository<Product>
{
    public async Task<List<Product>> GetProductsWithCategoryAsync()
    {
        return await _dbSet.Include(p => p.Category).ToListAsync();
    }
}
