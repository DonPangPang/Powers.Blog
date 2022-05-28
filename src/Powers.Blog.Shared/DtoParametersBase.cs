using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.Blog.Shared
{
    public interface IDtoParameters
    {
    }

    public class DtoParametersBase : IDtoParameters
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// 搜索字段
        /// </summary>
        public string? Q { get; set; }
    }
}