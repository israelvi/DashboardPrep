using System;
using Autofac;
using Dashboards.App_Start;
using Dashboards.Models.Constants;
using Dashboards.Models.Dto;
using Dashboards.Service;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Dashboards.Hubs
{

    [HubName(SharedConstants.PREP_HUB)]
    public class PrepHub : Hub
    {
        [HubMethodName(SharedConstants.LAST_RESULTS_PREP_HUB_METHOD)]
        public ResponseMessageData<string> LastResult(int candidateType)
        {
            try
            {
                return new ResponseMessageData<string>
                {
                    IsSuccess = true,
                    LstData = AppInit.Container.Resolve<IPrepService>().LastResult(candidateType)
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageData<string>
                {
                    IsSuccess = false,
                    Message = ex.Message + ex.StackTrace
                };
            }
        }
    }
}

