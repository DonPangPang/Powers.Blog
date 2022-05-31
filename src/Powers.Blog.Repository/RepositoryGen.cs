using Microsoft.EntityFrameworkCore;
using Powers.Blog.Common;
using Powers.Blog.EfCore;
using Powers.Blog.IRepository;
using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powers.Blog.Repository
{
    public class RepositoryGen<TId> : IRepositoryGen<TId>
    {
        private readonly PowersBlogDbContext _dbContext;

        public RepositoryGen(PowersBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.Remove(entity);

            return SaveChanges();
        }

        public bool Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.RemoveRange(entities);

            return SaveChanges();
        }

        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Task.Run(() =>
            {
                return Delete(entity);
            });
        }

        public async Task<bool> DeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Task.Run(() =>
            {
                return Delete(entities);
            });
        }

        public bool Disable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.EnableMark = false;
            return Update(entity);
        }

        public async Task<bool> DisableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.EnableMark = false;
            return await UpdateAsync(entity);
        }

        public bool Enable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.EnableMark = true;
            return Update(entity);
        }

        public async Task<bool> EnableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.EnableMark = true;
            return await UpdateAsync(entity);
        }

        public bool Insert<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.Add(entity);

            return SaveChanges();
        }

        public bool Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.AddRange(entities);

            return SaveChanges();
        }

        public async Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            await _dbContext.AddAsync(entity);

            return await SaveChangesAsync();
        }

        public async Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            await _dbContext.AddRangeAsync(entities);

            return await SaveChangesAsync();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> QueryAll<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return Query<TEntity>().ToList();
        }

        public IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return Query<TEntity>().Where(expression).ToList();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Query<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Query<TEntity>().Where(expression).ToListAsync();
        }

        public TEntity QueryById<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return Query<TEntity>().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<TEntity> QueryByIdAsync<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Query<TEntity>().Where(x => x.Id!.Equals(id)).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> QueryByIds<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return Query<TEntity>().Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task<IEnumerable<TEntity>> QueryByIdsAsync<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Query<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public PagedList<TEntity> QueryPaged<TEntity>(IQueryable<TEntity> source, IPaging paging) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return PagedList<TEntity>.Create(source, paging.Page, paging.PageSize);
        }

        public async Task<PagedList<TEntity>> QueryPagedAsync<TEntity>(IQueryable<TEntity> source, IPaging paging) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await PagedList<TEntity>.CreateAsync(source, paging.Page, paging.PageSize);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.Update(entity);

            return SaveChanges();
        }

        public bool Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            _dbContext.UpdateRange(entities);

            return SaveChanges();
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Task.Run(() =>
            {
                _dbContext.Update(entity);

                return SaveChangesAsync();
            });
        }

        public async Task<bool> UpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await Task.Run(() =>
            {
                _dbContext.Update(entities);

                return SaveChangesAsync();
            });
        }

        public bool VirtualDelete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.DeleteMark = true;
            return Update(entity);
        }

        public bool VirtualDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            foreach (var entity in entities)
            {
                entity.DeleteMark = true;
            }

            return Update(entities);
        }

        public async Task<bool> VirtualDeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            entity.DeleteMark = true;

            return await UpdateAsync(entity);
        }

        public async Task<bool> VirtualDeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            foreach (var entity in entities)
            {
                entity.DeleteMark = true;
            }

            return await UpdateAsync(entities);
        }
    }
}