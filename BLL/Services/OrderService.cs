using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository = new();

        public async Task<List<Order>> GetAllAsync() => await _orderRepository.GetAllAsync();

        public async Task<Order?> GetByIdAsync(int id) => await _orderRepository.GetOrderWithDetailsAsync(id);

        public async Task AddAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _orderRepository.Remove(order);
            await _orderRepository.SaveChangesAsync();
        }
    }

}
