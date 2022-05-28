using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Powers.Blog.IRepository
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>, IEntity
    {
        TEntity QueryById(TId id);

        Task<TEntity> QueryByIdAsync(TId id);

        IEnumerable<TEntity> QueryByIds(IEnumerable<TId> ids);

        Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<TId> ids);

        IEnumerable<TEntity> QueryAll();

        Task<IEnumerable<TEntity>> QueryAllAsync();

        IEnumerable<TEntity> QueryAll(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> QueryAllAsync(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> Query();

        bool Insert(TEntity entity);

        Task<bool> InsertAsync(TEntity entity);

        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        bool VirtualDelete(TEntity entity);

        Task<bool> VirtualDeleteAsync(TEntity entity);

        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}