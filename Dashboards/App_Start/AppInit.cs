using Autofac;
using Dashboards.ConnectCallCenter;

namespace Dashboards.App_Start
{
    public class AppInit
    {
        public static IContainer Container;
        public static void Start()
        {
            var bootstrapper = new Bootstrapper();
            Container = bootstrapper.Build();

        }
    }
}
