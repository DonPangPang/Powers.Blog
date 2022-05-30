using System;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; } = null!;

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}