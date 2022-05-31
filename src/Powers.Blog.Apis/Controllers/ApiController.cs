using Microsoft.AspNetCore.Mvc;
using Pang.AutoMapperMiddleware;
using Powers.Blog.Common;
using Powers.Blog.Common.Extensions;
using Powers.Blog.IServices;
using Powers.Blog.Shared;

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
        /// <returns> </returns>
        [NonAction]
        public ActionResult Success(string message = "操作成功")
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Success,
                Message = message
            });
        }

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
        /// <returns> </returns>
        [NonAction]
        public ActionResult Fail(string message = "操作失败")
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Fail,
                Message = message,
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

    /// <summary>
    /// 基础Api
    /// </summary>
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class ApiController<TId, TEntity> : ControllerBase
        where TEntity : EntityBase<TId>, IEntity, IEntityEnable, IEntityDelete
    {
        private readonly IServiceGen<TId> _serviceGen;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceGen"></param>
        public ApiController(IServiceGen<TId> serviceGen)
        {
            _serviceGen = serviceGen;
        }

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetPagedAsync([FromQuery] DtoParametersBase parameters)
        {
            var query = _serviceGen.Query<TEntity>();

            if (parameters.StartTime is not null && parameters.EndTime is not null)
            {
                query = query.Where(x => x.CreateDate >= parameters.StartTime && x.CreateDate <= parameters.EndTime);
            }

            var data = await query.ToPagedListAsync(parameters);
            return Success(data);
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var data = await _serviceGen.QueryAllAsync<TEntity>();
            return Success(data);
        }

        /// <summary>
        /// 通过Id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetByIdAsync(TId id)
        {
            var data = await _serviceGen.QueryByIdAsync<TEntity>(id);
            return Success(data);
        }

        /// <summary>
        /// 根据Id集合获取数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetByIdsAsync(IEnumerable<TId> ids)
        {
            var data = await _serviceGen.QueryByIdsAsync<TEntity>(ids);
            return Success(data);
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] TEntity entity)
        {
            var data = await _serviceGen.InsertAsync(entity);
            return data ? Success() : Fail();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] TEntity entity)
        {
            var old = await _serviceGen.QueryByIdAsync<TEntity>(entity.Id);

            entity!.Map<TEntity>(old);

            var data = await _serviceGen.UpdateAsync(old);
            return data ? Success() : Fail();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(TId id)
        {
            var deleted = await _serviceGen.QueryByIdAsync<TEntity>(id);
            var data = await _serviceGen.DeleteAsync(deleted);
            return data ? Success() : Fail();
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message"> </param>
        /// <returns> </returns>
        [NonAction]
        public ActionResult Success(string message = "操作成功")
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Success,
                Message = message
            });
        }

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
        /// <returns> </returns>
        [NonAction]
        public ActionResult Fail(string message = "操作失败")
        {
            return Ok(new UICallBack
            {
                Code = Common.StatusCode.Fail,
                Message = message,
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