using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Shared;
using System;

namespace Powers.Blog.Services
{
    public class ServiceGen<TEntity> : ServiceBase<TEntity, Guid>, IServiceGen<TEntity>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IRepositoryBase<TEntity, Guid> _repository;

        public ServiceGen(IRepositoryBase<TEntity, Guid> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}