using Powers.Blog.Common;
using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Powers.Blog.IRepository
{
    /// <summary>
    /// 通用仓储
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    public interface IRepositoryGen<TId>
    //where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="paging"> </param>
        /// <returns> </returns>
        PagedList<TEntity> QueryPaged<TEntity>(IQueryable<TEntity> source, IPaging paging) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="paging"> </param>
        /// <returns> </returns>
        Task<PagedList<TEntity>> QueryPagedAsync<TEntity>(IQueryable<TEntity> source, IPaging paging) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        TEntity QueryById<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        Task<TEntity> QueryByIdAsync<TEntity>(TId id) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="ids"> </param>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryByIds<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="ids"> </param>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryByIdsAsync<TEntity>(IEnumerable<TId> ids) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryAll<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<TEntity>> QueryAllAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 获取当前查询
        /// </summary>
        /// <returns> </returns>
        IQueryable<TEntity> Query<TEntity>() where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Insert<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Update<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> UpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Delete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool VirtualDelete<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> VirtualDeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool VirtualDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 虚拟删除
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> VirtualDeleteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Enable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> EnableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool Disable<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task<bool> DisableAsync<TEntity>(TEntity entity) where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete;

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