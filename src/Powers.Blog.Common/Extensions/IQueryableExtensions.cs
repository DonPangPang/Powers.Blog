using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Powers.Blog.Shared;

namespace Powers.Blog.Common.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// 进行排序
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="source">  </param>
        /// <param name="orderBy"> </param>
        /// <returns> </returns>
        public static IQueryable<T> ApplySort<T>(
            this IQueryable<T> source, string orderBy) where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByAfterSplit = orderBy.Split(",");

            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimedOrderByClause = orderByClause.Trim();

                var orderDescending = trimedOrderByClause.EndsWith(" desc");

                var indexOfFirstSpace = trimedOrderByClause.IndexOf(" ", StringComparison.Ordinal);

                var propertyName = indexOfFirstSpace == -1
                    ? trimedOrderByClause
                    : trimedOrderByClause.Remove(indexOfFirstSpace);

                source = source.OrderBy(propertyName
                                        + (orderDescending ? " descending" : " ascending"));
            }

            return source;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="source"> </param>
        /// <param name="paging"> </param>
        /// <returns> </returns>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, IPaging paging) where T : class
        {
            return await PagedList<T>.CreateAsync(source, paging.Page, paging.PageSize);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="source"> </param>
        /// <param name="paging"> </param>
        /// <returns> </returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, IPaging paging) where T : class
        {
            return PagedList<T>.Create(source, paging.Page, paging.PageSize);
        }
    }
}