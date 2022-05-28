using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 博客
    /// </summary>
    public class Weblog : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        /// <summary>
        /// 标签
        /// </summary>
        public ICollection<Tag>? Tags { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public ICollection<Category>? Categories { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; } = null!;

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}