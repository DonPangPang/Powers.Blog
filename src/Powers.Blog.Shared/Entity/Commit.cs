using System;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Commit : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 博客Id
        /// </summary>
        public Guid WeblogId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// 父节点
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 父节点评论人名称
        /// </summary>
        public string? ParentUserName { get; set; }

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}