using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem> 
    {
        public async Task<List<CartItem>> GetAllCartItemWithProductAsync()
        {
            return await _dbSet.Include(ci => ci.Product).ToListAsync();
        }

        public async Task<bool> ExistsByProductIdAsync(int productId)
        {
            return await _dbSet.AnyAsync(c => c.ProductId == productId);
        }
    }

}
