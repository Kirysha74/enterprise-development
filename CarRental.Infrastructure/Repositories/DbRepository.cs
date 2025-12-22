using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories;

public class DbRepository<T>(AppDbContext context) : IRepository<T> where T : class
{
    protected readonly DbSet<T> _set = context.Set<T>();

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _set.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _set.FindAsync(id);
        if (entity == null)
            return false;

        _set.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}