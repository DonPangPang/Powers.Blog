using System;
using System.Collections.Generic;
using System.Linq;

namespace Powers.Blog.Core.Utility
{
    public static class FormatExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullOrEmpty(this Guid? id)
        {
            return id is null || id.Equals(Guid.Empty);
        }

        public static bool IsNullOrEmpty(this DateTime? dt)
        {
            return dt is null || dt.Equals(DateTime.MinValue);
        }

        public static bool IsNullOrEmpty(this object? obj)
        {
            return obj is null;
        }

        public static bool IsNullOrEmpty<T>(this IList<T> lst)
        {
            return lst is null || !lst.Any();
        }

        public static bool IsNullOrEmpty<T>(this T? obj)
        {
            return obj is null || obj.Equals(default(T));
        }

        /// <summary>
        /// 将值转为对应的值类型
        /// </summary>
        /// <typeparam name="T"> 类型 </typeparam>
        /// <param name="value">        值 </param>
        /// <param name="defaultValue"> 默认值 </param>
        /// <returns> </returns>
        public static T? ConvertTo<T>(this object? value, T? defaultValue = default)
        {
            if (value is null)
                return defaultValue;

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                if (typeof(T) == typeof(Guid))
                    return (T)Convert.ChangeType(Guid.Parse(value.ToString() ?? ""), typeof(T));

                if (typeof(T) == typeof(DateTime))
                    return (T)Convert.ChangeType(DateTime.Parse(value.ToString() ?? ""), typeof(T));

                if (typeof(T).IsEnum)
                    return (T)Convert.ChangeType(Enum.Parse(typeof(T), value.ToString() ?? ""), typeof(T));

                return defaultValue;
            }
        }
    }
}