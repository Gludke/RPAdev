using RPAdev.Domain.Models;
using System.Linq.Expressions;

namespace RPAdev.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Remove(Guid id);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
