using Powers.Blog.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 点赞推荐
    /// </summary>
    public class StarRecord : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 博客Id
        /// </summary>
        public Guid WeblogId { get; set; }

        /// <summary>
        /// 点赞类型: 点赞/推荐
        /// </summary>
        public StarType StarType { get; set; }

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}