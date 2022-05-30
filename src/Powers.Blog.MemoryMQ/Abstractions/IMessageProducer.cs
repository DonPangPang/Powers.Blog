using System;
using System.Threading;
using System.Threading.Tasks;

namespace Powers.Blog.MemoryMQ.Abstractions
{
    public interface IMessageProducer<TKey, TValue> : IPubSub, IDisposable
    {
        ValueTask ProduceAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
    }
}