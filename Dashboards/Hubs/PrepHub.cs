using System;
using Autofac;
using Dashboards.App_Start;
using Dashboards.Models;
using Dashboards.Models.Dto;
using Dashboards.Service;

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
}

