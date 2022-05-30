using System;
using System.Threading;

namespace Powers.Blog.MemoryMQ.Abstractions
{
    public interface IMessageConsumer<TKey, TValue> : IPubSub, IDisposable
    {
        void OnMessage(Action<(TKey, TValue)> callback);

        CancellationTokenSource Cancel();

        void Subscribe();

        void Unsubscribe();
    }
}