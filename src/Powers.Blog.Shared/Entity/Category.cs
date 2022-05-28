using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; } = null!;

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}