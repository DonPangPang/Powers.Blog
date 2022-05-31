using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 点赞接口
    /// </summary>
    public class StarRecordController : ApiController<Guid, StarRecord>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        /// <returns></returns>
        public StarRecordController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
        }
    }
}