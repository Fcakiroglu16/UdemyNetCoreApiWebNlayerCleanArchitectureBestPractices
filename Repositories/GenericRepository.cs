using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories;

public class GenericRepository<T, TId>(AppDbContext context)
    : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : struct
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    protected AppDbContext Context = context;


    public Task<bool> AnyAsync(TId id)
    {
        return _dbSet.AnyAsync(x => x.Id.Equals(id));
    }


    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable().AsNoTracking();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).AsNoTracking();
    }


    public ValueTask<T?> GetByIdAsync(int id)
    {
        return _dbSet.FindAsync(id);
    }

    public async ValueTask AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}