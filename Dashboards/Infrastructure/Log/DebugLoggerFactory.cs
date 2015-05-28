using System;

namespace Dashboards.Infrastructure.Log
{
    public class DebugLoggerFactory : ILoggerFactory
    {
        public ILog Create(Type type)
        {
            return new DebugLogger(type.Name);
        }
    }
}
