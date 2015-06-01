using System;
using Autofac;
using Dashboards.App_Start;
using Dashboards.Models.Dto;
using Dashboards.Service;

namespace Dashboards.Hubs
{

    public class ElectionDayHub : BaseHub
    {

        public ResponseMessageData<ElectionResGeneral> LastUpdate(ElectionDayParams electionDayParams)
        {
            try
            {
                var result = AppInit.Container.Resolve<IElectionDayService>().LastUpdate(electionDayParams);

                if (result == null)
                {
                    return new ResponseMessageData<ElectionResGeneral>
                    {
                        IsSuccess = false,
                        Message = "No se encontró información con el filtro seleccionado"
                    };
                }

                return new ResponseMessageData<ElectionResGeneral>
                {
                    IsSuccess = true,
                    LstData = result
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageData<ElectionResGeneral>
                {
                    IsSuccess = false,
                    Message = ex.Message + ex.StackTrace
                };
            }
        }

        public ResponseMessageData<CatalogsDistrictRes> CatalogsDistrict()
        {
            try
            {
                var result = AppInit.Container.Resolve<IElectionDayService>().CatalogsDistrict();

                if (result == null)
                {
                    return new ResponseMessageData<CatalogsDistrictRes>
                    {
                        IsSuccess = false,
                        Message = "No se encontró información con el filtro seleccionado"
                    };
                }

                return new ResponseMessageData<CatalogsDistrictRes>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageData<CatalogsDistrictRes>
                {
                    IsSuccess = false,
                    Message = ex.Message + ex.StackTrace
                };
            }
        }

        public ResponseMessageData<CatalogsDistrictRes> CatalogsDistrictByRegionId(int regionId)
        {
            try
            {
                var result = AppInit.Container.Resolve<IElectionDayService>().CatalogsDistrictByRegionId(regionId);

                if (result == null)
                {
                    return new ResponseMessageData<CatalogsDistrictRes>
                    {
                        IsSuccess = false,
                        Message = "No se encontró información con el filtro seleccionado"
                    };
                }

                return new ResponseMessageData<CatalogsDistrictRes>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageData<CatalogsDistrictRes>
                {
                    IsSuccess = false,
                    Message = ex.Message + ex.StackTrace
                };
            }
        }
    }
}

