
using Autofac;
using Dashboards.Infrastructure;
using Dashboards.Infrastructure.Log;

namespace Dashboards
{
    public abstract class BootstrapperBase
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DebugLoggerFactory>().As<ILoggerFactory>().SingleInstance();
            RegisterTypes(builder);
            return builder.Build();
        }

        protected abstract void RegisterTypes(ContainerBuilder builder);
    }
}
