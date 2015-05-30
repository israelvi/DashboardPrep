using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Dashboards.App_Start;
using Dashboards.Infrastructure.Connection;
using Dashboards.Models;
using Dashboards.Models.Dto;
using Dashboards.Service;
using Microsoft.AspNet.SignalR;

namespace Dashboards.Hubs
{

    public class PrepHub : BaseHub
    {

        public ResponseMessageData<EleccionesDto> LastResult(int candidateType)
        {
            try
            {
                return new ResponseMessageData<EleccionesDto>
                {
                    IsSuccess = true,
                    LstData = AppInit.Container.Resolve<IPrepService>().LastResult(candidateType)
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageData<EleccionesDto>
                {
                    IsSuccess = false,
                    Message = ex.Message + ex.StackTrace
                };
            }
        }

        //private void ExecuteLater()
        //{
        //    Thread.Sleep(5000);
        //    AppInit.Container.Resolve<PrepHub>().Clients.All.lastResultProp(new EleccionesDto
        //    {
        //        Morena = 10,
        //        Otros = 5,
        //        Pan = 5
        //    });
        //}
    }

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

