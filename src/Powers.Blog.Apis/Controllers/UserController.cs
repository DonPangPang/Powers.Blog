using Microsoft.AspNetCore.Mvc;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserController : ApiController<Guid, User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        /// <returns></returns>
        public UserController(IServiceGen<Guid> serviceGen) : base(serviceGen)
        {
        }
    }
}