using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class UserService
{
    private readonly UserRepository _userRepository = new();

    public async Task<List<User>> GetAllAsync() => await _userRepository.GetAllAsync();

    public async Task<User?> GetByIdAsync(int id) => await _userRepository.GetUserWithOrdersAsync(id);

    public async Task AddAsync(User user)
    {
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _userRepository.Remove(user);
        await _userRepository.SaveChangesAsync();
    }
}
