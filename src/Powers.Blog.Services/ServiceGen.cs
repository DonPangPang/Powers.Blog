using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Shared;
using System;

namespace Powers.Blog.Services
{
    public class ServiceGen<TEntity> : ServiceBase<TEntity, Guid>, IServiceGen<TEntity>
        where TEntity : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IRepositoryGen<TEntity> _repository;

        public ServiceGen(IRepositoryGen<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}