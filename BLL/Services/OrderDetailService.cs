using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class OrderDetailService
{
    private readonly OrderDetailRepository _orderDetailRepository = new();

    public async Task<List<OrderDetail>> GetAllAsync() => await _orderDetailRepository.GetAllAsync();

    public async Task<OrderDetail?> GetByIdAsync(int id) => await _orderDetailRepository.GetByIdAsync(id);

    public async Task AddAsync(OrderDetail detail)
    {
        await _orderDetailRepository.AddAsync(detail);
        await _orderDetailRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderDetail detail)
    {
        _orderDetailRepository.Update(detail);
        await _orderDetailRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(OrderDetail detail)
    {
        _orderDetailRepository.Remove(detail);
        await _orderDetailRepository.SaveChangesAsync();
    }
}
