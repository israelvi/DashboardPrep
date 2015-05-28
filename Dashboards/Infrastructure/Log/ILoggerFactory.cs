using System;

namespace Dashboards.Infrastructure.Log
{
    public interface ILoggerFactory
    {
        ILog Create(Type type);
    }
}
