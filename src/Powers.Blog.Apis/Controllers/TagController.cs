using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 标签接口
    /// </summary>
    public class TagController : ApiController<Guid, Tag>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        /// <returns></returns>
        public TagController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
        }
    }
}