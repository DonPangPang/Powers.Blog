using Microsoft.EntityFrameworkCore;
using Powers.Blog.IRepository;
using Powers.Blog.Shared;
using Powers.Blog.Shared.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powers.Blog.Repository
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly PowersBlogDbContext _dbContext;

        public RepositoryBase(PowersBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(TEntity entity)
        {
            _dbContext.Remove(entity);

            return SaveChanges();
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);

            return SaveChanges();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                return Delete(entity);
            });
        }

        public async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
        {
            return await Task.Run(() =>
            {
                return Delete(entities);
            });
        }

        public bool Disable(TEntity entity)
        {
            entity.EnableMark = false;
            return Update(entity);
        }

        public async Task<bool> DisableAsync(TEntity entity)
        {
            entity.EnableMark = false;
            return await UpdateAsync(entity);
        }

        public bool Enable(TEntity entity)
        {
            entity.EnableMark = true;
            return Update(entity);
        }

        public async Task<bool> EnableAsync(TEntity entity)
        {
            entity.EnableMark = true;
            return await UpdateAsync(entity);
        }

        public bool Insert(TEntity entity)
        {
            _dbContext.Add(entity);

            return SaveChanges();
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            _dbContext.AddRange(entities);

            return SaveChanges();
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);

            return await SaveChangesAsync();
        }

        public async Task<bool> InsertAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);

            return await SaveChangesAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> QueryAll()
        {
            return Query().ToList();
        }

        public IEnumerable<TEntity> QueryAll(Expression<Func<TEntity, bool>> expression)
        {
            return Query().Where(expression).ToList();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Query().Where(expression).ToListAsync();
        }

        public TEntity QueryById(TId id)
        {
            return Query().Where(x => x.Id!.Equals(id)).FirstOrDefault();
        }

        public Task<TEntity> QueryByIdAsync(TId id)
        {
            return Query().Where(x => x.Id!.Equals(id)).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> QueryByIds(IEnumerable<TId> ids)
        {
            return Query().Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<TId> ids)
        {
            return await Query().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool Update(TEntity entity)
        {
            _dbContext.Update(entity);

            return SaveChanges();
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);

            return SaveChanges();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _dbContext.Update(entity);

                return SaveChangesAsync();
            });
        }

        public async Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
        {
            return await Task.Run(() =>
            {
                _dbContext.UpdateRange(entities);

                return SaveChangesAsync();
            });
        }

        public bool VirtualDelete(TEntity entity)
        {
            entity.DeleteMark = true;
            return Update(entity);
        }

        public bool VirtualDelete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DeleteMark = true;
            }

            return Update(entities);
        }

        public async Task<bool> VirtualDeleteAsync(TEntity entity)
        {
            entity.DeleteMark = true;

            return await UpdateAsync(entity);
        }

        public async Task<bool> VirtualDeleteAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DeleteMark = true;
            }

            return await UpdateAsync(entities);
        }
    }
}