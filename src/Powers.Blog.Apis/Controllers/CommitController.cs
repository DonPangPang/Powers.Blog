using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 评论接口
    /// </summary>
    public class CommitController : ApiController<Guid, Commit>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        /// <returns></returns>
        public CommitController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
        }
    }
}