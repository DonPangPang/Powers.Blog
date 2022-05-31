using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powers.Blog.Shared
{
    /// <summary>
    /// 排序
    /// </summary>
    public interface ISorting : IDtoParameters
    {
        /// <summary>
        /// 排序
        /// </summary>
        public string? OrderBy { get; set; }
    }
}