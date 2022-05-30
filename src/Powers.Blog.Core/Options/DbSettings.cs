using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Powers.Blog.Core.Options
{
    /// <summary>
    /// 数据库设置
    /// </summary>
    public class DbSettings : IOptions<DbSettings>
    {
        public IEnumerable<DbSetting> Settings { get; set; }

        public DbSettings Value => this;
    }

    /// <summary>
    /// 数据库设置
    /// </summary>
    public class DbSetting
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool IsEnable { get; set; } = false;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}