using Powers.Blog.Common;
using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powers.Blog.IServices
{
    /// <summary>
    /// 基础服务
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    /// <typeparam name="TId"> </typeparam>
    public interface IServiceBase<TEntity, TId>
        where TEntity : EntityBase<TId>, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameters"> </param>
        /// <returns> </returns>
        PagedList<TEntity> QueryPaged(IDtoParameters parameters);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameters"> </param>
        /// <returns> </returns>
        Task<PagedList<TEntity>> QueryPagedAsync(IDtoParameters parameters);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        TEntity QueryById(TId id);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        Task<TEntity> QueryByIdAsync(TId id);

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="ids"> </param>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryByIds(IEnumerable<TId> ids);

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="ids"> </param>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryByIdsAsync(IEnumerable<TId> ids);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryAll();

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryAllAsync();

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryAll(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryAllAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 获取当前查询
        /// </summary>
        /// <returns> </returns>
        IQueryable<TEntity> Query();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Insert(TEntity entity);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> InsertAsync(TEntity entity);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> InsertAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> UpdateAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DeleteAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool VirtualDelete(TEntity entity);

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> VirtualDeleteAsync(TEntity entity);

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool VirtualDelete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> VirtualDeleteAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Enable(TEntity entity);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> EnableAsync(TEntity entity);

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Disable(TEntity entity);

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DisableAsync(TEntity entity);

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns> </returns>
        bool SaveChanges();

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns> </returns>
        Task<bool> SaveChangesAsync();
    }
}