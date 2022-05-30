using Powers.Blog.EfCore;
using Powers.Blog.Shared;
using System;

namespace Powers.Blog.Repository
{
    public class RepositoryGen<TEntity> : RepositoryBase<TEntity, Guid>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        public RepositoryGen(PowersBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}