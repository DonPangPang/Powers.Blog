using System;

namespace Powers.Blog.Shared
{
    public interface IEntity
    {
    }

    public abstract class EntityBase<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        public T Id { get; set; }

        public T? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUserName { get; set; }

        public T? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModifyUserName { get; set; }
    }

    public interface IEntityEnable
    {
        /// <summary>
        /// 开启标记
        /// </summary>
        public bool EnableMark { get; set; }
    }

    public interface IEntityDelete
    {
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool DeleteMark { get; set; }
    }
}