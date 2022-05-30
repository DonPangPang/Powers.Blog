namespace Powers.Blog.MemoryMQ.Abstractions
{
    public interface IPubSub
    {
        /// <summary>
        /// 主题
        /// </summary>
        string TopicName { get; set; }
    }
}