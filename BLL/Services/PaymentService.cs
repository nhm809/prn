using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class PaymentService
{
    private readonly PaymentRepository _paymentRepository = new();

    public async Task<List<Payment>> GetAllAsync() => await _paymentRepository.GetAllAsync();

    public async Task<Payment?> GetByIdAsync(int id) => await _paymentRepository.GetByIdAsync(id);

    public async Task AddAsync(Payment payment)
    {
        await _paymentRepository.AddAsync(payment);
        await _paymentRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        _paymentRepository.Update(payment);
        await _paymentRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Payment payment)
    {
        _paymentRepository.Remove(payment);
        await _paymentRepository.SaveChangesAsync();
    }
}
