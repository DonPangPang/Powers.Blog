using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Powers.Blog.Shared.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : EntityBase<Guid>, IEntity, IEntityEnable, IEntityDelete
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        public string Account { get; set; } = null!;

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// 个性签名
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 个人Url地址
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public bool IsSuper { get; set; } = false;

        public bool EnableMark { get; set; } = true;
        public bool DeleteMark { get; set; } = false;
    }
}