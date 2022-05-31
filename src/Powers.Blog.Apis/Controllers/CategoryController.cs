using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 分类接口
    /// </summary>
    public class CategoryController : ApiController<Guid, Category>
    {
        private readonly IServiceGen<Guid> _serviceGen;

        /// <summary>
        /// 
        /// </summary>
        public CategoryController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
            _serviceGen = serviceGen;
        }

        /// <summary>
        /// 根据分类获取博客
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBlogsFromCategory(Guid categoryId)
        {
            var data = await _serviceGen.Query<Weblog>()
                .Include(x => x.Categories)
                .Where(x => x.Categories!.Select(t => t.Id).Contains(categoryId))
                .ToListAsync();

            return Success(data);
        }
    }
}