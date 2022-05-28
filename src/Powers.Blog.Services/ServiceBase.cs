using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powers.Blog.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IRepositoryBase<TEntity, Guid> _repository;

        public ServiceBase(IRepositoryBase<TEntity, Guid> repository)
        {
            _repository = repository;
        }

        public bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            return _repository.Delete(entities);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.DeleteAsync(entities);
        }

        public bool Disable(TEntity entity)
        {
            return _repository.Disable(entity);
        }

        public async Task<bool> DisableAsync(TEntity entity)
        {
            return await _repository.DisableAsync(entity);
        }

        public bool Enable(TEntity entity)
        {
            return _repository.Enable(entity);
        }

        public Task<bool> EnableAsync(TEntity entity)
        {
            return _repository.EnableAsync(entity);
        }

        public bool Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            return _repository.Insert(entities);
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> InsertAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.InsertAsync(entities);
        }

        public IQueryable<TEntity> Query()
        {
            return _repository.Query();
        }

        public IEnumerable<TEntity> QueryAll()
        {
            return _repository.QueryAll();
        }

        public IEnumerable<TEntity> QueryAll(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.QueryAll(expression);
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync()
        {
            return await _repository.QueryAllAsync();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.QueryAllAsync(expression);
        }

        public TEntity QueryById(Guid id)
        {
            return _repository.QueryById(id);
        }

        public async Task<TEntity> QueryByIdAsync(Guid id)
        {
            return await _repository.QueryByIdAsync(id);
        }

        public IEnumerable<TEntity> QueryByIds(IEnumerable<Guid> ids)
        {
            return _repository.QueryByIds(ids);
        }

        public async Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _repository.QueryByIdsAsync(ids);
        }

        public bool SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }

        public bool Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            return _repository.Update(entities);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.UpdateAsync(entities);
        }

        public bool VirtualDelete(TEntity entity)
        {
            return _repository.VirtualDelete(entity);
        }

        public bool VirtualDelete(IEnumerable<TEntity> entities)
        {
            return _repository.VirtualDelete(entities);
        }

        public async Task<bool> VirtualDeleteAsync(TEntity entity)
        {
            return await _repository.VirtualDeleteAsync(entity);
        }

        public async Task<bool> VirtualDeleteAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.VirtualDeleteAsync(entities);
        }
    }
}