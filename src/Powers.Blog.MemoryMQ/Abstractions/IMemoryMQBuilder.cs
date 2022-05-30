using Microsoft.Extensions.DependencyInjection;

namespace Powers.Blog.MemoryMQ.Abstractions
{
    public interface IMemoryMQBuilder
    {
        IServiceCollection Services { get; set; }
    }

    public interface IMemoryMQCustomBuilder
    {
        IMemoryMQBuilder MemoryMQBuilder { get; }

        IMemoryMQBuilder BUilder();
    }
}