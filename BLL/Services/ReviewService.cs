using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class ReviewService
{
    private readonly ReviewRepository _reviewRepository = new();

    public async Task<List<Review>> GetAllAsync() => await _reviewRepository.GetAllAsync();

    public async Task<Review?> GetByIdAsync(int id) => await _reviewRepository.GetByIdAsync(id);

    public async Task AddAsync(Review review)
    {
        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        _reviewRepository.Update(review);
        await _reviewRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Review review)
    {
        _reviewRepository.Remove(review);
        await _reviewRepository.SaveChangesAsync();
    }
}
