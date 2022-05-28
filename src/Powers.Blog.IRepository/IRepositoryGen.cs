using Powers.Blog.Shared;
using System;

namespace Powers.Blog.IRepository
{
    public interface IRepositoryGen<TEntity> : IRepositoryBase<TEntity, Guid>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
    }
}