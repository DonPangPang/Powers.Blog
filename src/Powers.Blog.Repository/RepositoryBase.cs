using Powers.Blog.IRepository;
using Powers.Blog.Shared;
using Powers.Blog.Shared.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Powers.Blog.Repository
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>, IEntity
    {
        private readonly PowersBlogDbContext _dbContext;

        public RepositoryBase(PowersBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Disable(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisableAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Enable(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> QueryAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> QueryAll(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> QueryAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity QueryById(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> QueryByIds(IEnumerable<TId> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<TId> ids)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool VirtualDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool VirtualDelete(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VirtualDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VirtualDeleteAsync(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}