using MenuApp.Core.DataAccess.Abstracts;
using MenuApp.Core.Entities.Abstracts;
using MenuApp.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Core.DataAccess.Concretes
{
    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsync() > 0 ? entity : null;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression is null)
            {
                var exist = await _dbSet.AnyAsync();
                if (exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var exist = await _dbSet.AnyAsync(expression);
                if (exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveAsync() > 0 ? entity : null;
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync() > 0 ? true : false;

        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression) => await _dbSet.Where(expression).FirstOrDefaultAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression) => await _dbSet.FirstOrDefaultAsync(expression);

        public async Task<List<TEntity>> GetAllAsync() => await _dbSet.Where(x => x.Status != Status.Passive).ToListAsync();

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression) => await _dbSet.Where(x => x.Status != Status.Passive).Where(expression).ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
