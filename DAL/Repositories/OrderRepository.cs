using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public async Task<Order?> GetOrderWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await GetByIdAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                Update(order);
                await SaveChangesAsync();
            }
        }
    }

}
