using Microsoft.AspNetCore.Mvc;
using Powers.Blog.Common;

namespace Powers.Blog.Apis.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class ApiController : ControllerBase
    {
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

        [NonAction]
        public ActionResult Success(object? data)
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Success,
                Data = data,
            });
        }

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