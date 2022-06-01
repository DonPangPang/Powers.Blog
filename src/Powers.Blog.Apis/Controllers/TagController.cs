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
    /// 标签接口
    /// </summary>
    public class TagController : ApiController<Guid, Tag>
    {
        private readonly IServiceGen<Guid> _serviceGen;

        /// <summary>
        /// </summary>
        /// <param name="serviceGen"> </param>
        /// <returns> </returns>
        public TagController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
            _serviceGen = serviceGen;
        }

        /// <summary>
        /// 根据标签获取博客
        /// </summary>
        /// <param name="tagId"> </param>
        /// <returns> </returns>
        [HttpGet]
        public async Task<ActionResult> GetBlogsFromTag(Guid tagId)
        {
            var data = await _serviceGen.Query<Weblog>()
                .Include(x => x.Tags)
                .Where(x => x.Tags!.Select(t => t.Id).Contains(tagId))
                .ToListAsync();

            return Success(data);
        }
    }
}