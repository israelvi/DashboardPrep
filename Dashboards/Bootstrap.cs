using Autofac;
using Dashboards.Service;

namespace Dashboards
{
    namespace ConnectCallCenter
    {
        public class Bootstrapper : BootstrapperBase
        {
            protected override void RegisterTypes(ContainerBuilder builder)
            {
                //builder.RegisterType<StoreRepository>().As<IStoreRepository>();
                builder.RegisterType<PrepService>().As<IPrepService>();
                //builder.RegisterType<OrderHub>().SingleInstance();
            }
        }
    }
}