using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Powers.Blog.Shared.Enums
{
    /// <summary>
    /// 点赞类型
    /// </summary>
    public enum StarType
    {
        /// <summary>
        /// 点赞
        /// </summary>
        [Description("点赞")]
        Star = 0,

        /// <summary>
        /// 推荐
        /// </summary>
        [Description("推荐")]
        Recommend = 1
    }
}