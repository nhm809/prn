using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository = new();

    public async Task<List<Category>> GetAllAsync() => await _categoryRepository.GetAllAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

    public async Task AddAsync(Category category)
    {
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _categoryRepository.Remove(category);
        await _categoryRepository.SaveChangesAsync();
    }
}
