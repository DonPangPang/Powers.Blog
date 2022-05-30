namespace Powers.Blog.Common
{
    public class UICallBack
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public StatusCode Code { get; set; } = StatusCode.Success;

        /// <summary>
        /// 消息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object? Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 200,
        Fail = 400
    }
}