using Microsoft.AspNetCore.Mvc;
using Powers.Blog.IServices;
using Powers.Blog.Shared.Entity;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// </summary>
        /// <param name="_userService"> </param>
        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var data = await _userService.QueryAllAsync();

            return Success(data);
        }
    }
}