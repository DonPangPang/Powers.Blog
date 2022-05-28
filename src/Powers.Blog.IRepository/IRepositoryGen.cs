﻿using Powers.Blog.Shared;
using System;

namespace Powers.Blog.IRepository
{
    /// <summary>
    /// 通用仓储
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    public interface IRepositoryGen<TEntity> : IRepositoryBase<TEntity, Guid>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
    }
}