using Newtonsoft.Json;
using System;

namespace Powers.Blog.Extensions
{
    /// <summary>
    /// Json处理相关扩展
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// 将对象转为Json字符串
        /// </summary>
        /// <param name="obj"> </param>
        /// <returns> </returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// 将Json转为对象
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="str"> </param>
        /// <returns> </returns>
        public static T? ToObject<T>(this string str) where T : class, new()
        {
            if (string.IsNullOrEmpty(str)) return null;

            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}