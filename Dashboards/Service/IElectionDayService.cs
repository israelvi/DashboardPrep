using System.Collections.Generic;
using Dashboards.Models.Dto;

namespace Dashboards.Service
{
    public interface IElectionDayService
    {
        IList<ElectionResGeneral> LastUpdate(ElectionDayParams electionDayParams);
        CatalogsDistrictRes CatalogsDistrict();
        CatalogsDistrictRes CatalogsDistrictByRegionId(int regionId);
    }
}