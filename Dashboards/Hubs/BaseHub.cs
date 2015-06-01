using System.Linq;
using System.Threading.Tasks;
using Dashboards.Infrastructure.Connection;
using Microsoft.AspNet.SignalR;

namespace Dashboards.Hubs
{
    public class BaseHub : Hub
    {
        private readonly static ConnectionMapping<string> Connections = new ConnectionMapping<string>();

        public ConnectionMapping<string> ConnectionInfo
        {
            get
            {
                return Connections;
            }
        }

        public override Task OnConnected()
        {
            var name = Context.ConnectionId;

            Connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.ConnectionId;

            Connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            var name = Context.ConnectionId;

            if (!Connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                Connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}