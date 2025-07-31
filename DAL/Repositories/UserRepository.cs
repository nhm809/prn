using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;
public class UserRepository : BaseRepository<User>
{
    public async Task<User?> GetUserWithOrdersAsync(int id)
    {
        return await _dbSet
            .Include(u => u.Orders)
            .Include(u => u.Reviews)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddUserAsync(User user)
    {
        await AddAsync(user);
        await SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        Update(user);
        await SaveChangesAsync();
    }

    public async Task RemoveUserAsync(User user)
    {
        Remove(user);
        await SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await GetByIdAsync(id);
    }
}
