using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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