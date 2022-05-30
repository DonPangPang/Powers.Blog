using Microsoft.AspNetCore.Mvc;
using Powers.Blog.Common;

namespace Powers.Blog.Apis.Controllers
{
    /// <summary>
    /// 基础Api
    /// </summary>
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="data">    </param>
        /// <returns> </returns>
        [NonAction]
        public ActionResult Success(string message, object? data)
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Success,
                Message = message,
                Data = data,
            });
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data"> </param>
        /// <returns> </returns>
        [NonAction]
        public ActionResult Success(object? data)
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Success,
                Data = data,
            });
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="data">    </param>
        /// <returns> </returns>
        [NonAction]
        public ActionResult Fail(string message, object? data)
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Fail,
                Message = message,
                Data = data,
            });
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="data"> </param>
        /// <returns> </returns>
        [NonAction]
        public ActionResult Fail(object? data)
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Fail,
                Data = data,
            });
        }
    }
}