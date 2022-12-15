using MealOrdering.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        IQueryable<TEntity> GetAll(bool tracking = false);
        Task<TEntity> GetByIdAsync(string id,bool tracking = false);
        Task<bool> AddAsync(TEntity model);
        Task<bool> RemoveAsync(string id);
        bool Remove(TEntity model);
        Task<int> SaveAsync();
        bool Update(TEntity model);
    }
}
