using System;
using System.Collections.Generic;
using Dashboards.Models;
using Dashboards.Models.Dto;

namespace Dashboards.Repository
{
    public interface IElectionDayRepository : IDisposable
    {
        IList<EleccionesDto> LastUpdate(ElectionDayParams electionDayParams);
        IList<ElectionResGeneral> LastUpdateGlobal(ElectionDayParams electionDayParams);
        IList<ItemModel> GetRegions();
        IList<ItemModel> GetCoordRegions();
        IList<ItemModel> GetLocRegions();
        IList<ElectionResGeneral> LastUpdateDistrict(ElectionDayParams electionDayParams);
        IList<ItemModel>    GetRegionsByRegionId(int regionId);
        IList<ItemModel> GetCoordRegionsByRegionId(int regionId);
        IList<ItemModel> GetLocRegionsByRegionId(int regionId);
        IList<ItemModel> GetIncidents();
        IList<ElectionResGeneral> LastUpdateRegion(ElectionDayParams electionDayParams);
    }
}