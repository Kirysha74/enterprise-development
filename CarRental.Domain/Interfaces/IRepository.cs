using System.Linq.Expressions;

namespace CarRental.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(int id);

    public Task<T?> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>>? include = null);
    public Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? include = null);
    public IQueryable<T> GetQueryable(Func<IQueryable<T>, IQueryable<T>>? include = null);
}