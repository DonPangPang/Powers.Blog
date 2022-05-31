using Powers.Blog.Common;
using Powers.Blog.Common.Extensions;
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
    public class ServiceBase<TEntity, TId> : IServiceBase<TEntity, TId>
        where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IRepositoryBase<TEntity, TId> _repository;

        public ServiceBase(IRepositoryBase<TEntity, TId> repository)
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

        public TEntity QueryById(TId id)
        {
            return _repository.QueryById(id);
        }

        public async Task<TEntity> QueryByIdAsync(TId id)
        {
            return await _repository.QueryByIdAsync(id);
        }

        public IEnumerable<TEntity> QueryByIds(IEnumerable<TId> ids)
        {
            return _repository.QueryByIds(ids);
        }

        public async Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<TId> ids)
        {
            return await _repository.QueryByIdsAsync(ids);
        }

        public PagedList<TEntity> QueryPaged(IDtoParameters parameters!!)
        {
            var query = Query();
            if (parameters is ISorting sorting)
                query.ApplySort(sorting.OrderBy ?? "");

            if (parameters is IPaging paging)
                return _repository.QueryPaged(query, paging);
            else
                throw new Exception("无分页参数");
        }

        public async Task<PagedList<TEntity>> QueryPagedAsync(IDtoParameters parameters!!)
        {
            var query = Query();
            if (parameters is ISorting sorting)
                query.ApplySort(sorting.OrderBy ?? "");

            if (parameters is IPaging paging)
                return await _repository.QueryPagedAsync(query, paging);
            else
                throw new Exception("无分页参数");
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