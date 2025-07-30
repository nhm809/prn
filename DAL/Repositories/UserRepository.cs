using DAL.Entities;
using DAL.Repositories;
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

}
