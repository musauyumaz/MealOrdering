using MealOrdering.Application.Repositories;
using MealOrdering.Domain.Entities.Common;
using MealOrdering.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MealOrdering.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MealOrderingDbContext _context;

        public Repository(MealOrderingDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity model)
        {
            EntityEntry entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public IQueryable<TEntity> GetAll(bool tracking = false)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }



        public async Task<TEntity> GetByIdAsync(string id, bool tracking = false)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }


        public bool Remove(TEntity model)
        {
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            TEntity? model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
