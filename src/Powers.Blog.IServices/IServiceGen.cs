using Powers.Blog.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.Blog.IServices
{
    /// <summary>
    /// 通用服务
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    public interface IServiceGen<TEntity> : IServiceBase<TEntity, Guid>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
    }
}