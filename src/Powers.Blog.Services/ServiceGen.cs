using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Powers.Blog.Common;
using Powers.Blog.Common.Extensions;

namespace Powers.Blog.Services
{
    public class ServiceGen<TId> : IServiceGen<TId>
    //where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IRepositoryGen<TId> _repository;

        public ServiceGen(IRepositoryGen<TId> repository)
        {
            _repository = repository;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Delete<TEntity>(entity);
        }

        public bool Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Delete<TEntity>(entities);
        }

        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.DeleteAsync<TEntity>(entity);
        }

        public async Task<bool> DeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.DeleteAsync<TEntity>(entities);
        }

        public bool Disable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Disable<TEntity>(entity);
        }

        public async Task<bool> DisableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.DisableAsync<TEntity>(entity);
        }

        public bool Enable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Enable<TEntity>(entity);
        }

        public Task<bool> EnableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.EnableAsync<TEntity>(entity);
        }

        public bool Insert<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Insert<TEntity>(entity);
        }

        public bool Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Insert<TEntity>(entities);
        }

        public async Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.InsertAsync<TEntity>(entity);
        }

        public async Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.InsertAsync<TEntity>(entities);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Query<TEntity>();
        }

        public IEnumerable<TEntity> QueryAll<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.QueryAll<TEntity>();
        }

        public IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.QueryAll<TEntity>(expression);
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.QueryAllAsync<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.QueryAllAsync<TEntity>(expression);
        }

        public TEntity QueryById<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.QueryById<TEntity>(id);
        }

        public async Task<TEntity> QueryByIdAsync<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.QueryByIdAsync<TEntity>(id);
        }

        public IEnumerable<TEntity> QueryByIds<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.QueryByIds<TEntity>(ids);
        }

        public async Task<IEnumerable<TEntity>> QueryByIdsAsync<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.QueryByIdsAsync<TEntity>(ids);
        }

        public PagedList<TEntity> QueryPaged<TEntity>(IDtoParameters parameters) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            var query = Query<TEntity>();
            if (parameters is ISorting sorting)
                query.ApplySort(sorting.OrderBy ?? "");

            if (parameters is IPaging paging)
                return _repository.QueryPaged(query, paging);
            else
                throw new Exception("无分页参数");
        }

        public async Task<PagedList<TEntity>> QueryPagedAsync<TEntity>(IDtoParameters parameters) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            var query = Query<TEntity>();
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

        public bool Update<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Update<TEntity>(entity);
        }

        public bool Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.Update<TEntity>(entities);
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.UpdateAsync<TEntity>(entity);
        }

        public async Task<bool> UpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.UpdateAsync<TEntity>(entities);
        }

        public bool VirtualDelete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.VirtualDelete<TEntity>(entity);
        }

        public bool VirtualDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return _repository.VirtualDelete<TEntity>(entities);
        }

        public async Task<bool> VirtualDeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.VirtualDeleteAsync<TEntity>(entity);
        }

        public async Task<bool> VirtualDeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
        {
            return await _repository.VirtualDeleteAsync<TEntity>(entities);
        }
    }
}