using System.Threading.Channels;

namespace Powers.Blog.MemoryMQ.Abstractions
{
    public class MessageChannel<TKey, TValue>
    {
        public Channel<(TKey, TValue)> Channel { get; }

        public MessageChannel()
        {
            Channel = System.Threading.Channels.Channel.CreateUnbounded<(TKey, TValue)>();
        }
    }
}