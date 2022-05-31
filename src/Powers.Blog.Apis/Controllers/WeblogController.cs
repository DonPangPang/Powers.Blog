using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 博客接口
    /// </summary>
    public class WeblogController : ApiController<Guid, Weblog>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        /// <returns></returns>
        public WeblogController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
        }
    }
}