using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services;

public class UserService
{
    private readonly UserRepository _userRepository = new();

    public async Task<List<User>> GetAllAsync()
        => await _userRepository.GetAllUsersAsync();

    public async Task<User?> GetByIdAsync(int id)
        => await _userRepository.GetUserByIdAsync(id);

    public async Task<User?> GetWithOrdersAsync(int id)
        => await _userRepository.GetUserWithOrdersAsync(id);

    public async Task<User?> FindByEmailAsync(string email)
        => await _userRepository.FindByEmailAsync(email);

    public async Task AddAsync(User user)
        => await _userRepository.AddUserAsync(user);

    public async Task UpdateAsync(User user)
        => await _userRepository.UpdateUserAsync(user);

    public async Task DeleteAsync(User user)
        => await _userRepository.RemoveUserAsync(user);
}