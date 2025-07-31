using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReviewRepository : BaseRepository<Review> {

        public async Task<bool> ExistsByProductIdAsync(int productId)
        {
            return await _dbSet.AnyAsync(r => r.ProductId == productId);
        }
    }

}
