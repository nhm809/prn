using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DAL.Data;

namespace DAL.Repositories;

public class BaseRepository<T> where T : class
{
    protected readonly FuminiLongChauSystemContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository()
    {
        _context = new FuminiLongChauSystemContext();
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
