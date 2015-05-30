using Autofac;
using Dashboards.Hubs;
using Dashboards.Repository;
using Dashboards.Service;

namespace Dashboards
{
    namespace ConnectCallCenter
    {
        public class Bootstrapper : BootstrapperBase
        {
            protected override void RegisterTypes(ContainerBuilder builder)
            {
                builder.RegisterType<PrepRepository>().As<IPrepRepository>();
                builder.RegisterType<PrepService>().As<IPrepService>();
                builder.RegisterType<PrepHub>().SingleInstance();
            }
        }
    }
}