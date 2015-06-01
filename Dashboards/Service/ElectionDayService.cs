using System;
using System.Collections.Generic;
using Dashboards.Models.Dto;
using Dashboards.Repository;

namespace Dashboards.Service
{
    public class ElectionDayService : IElectionDayService
    {
        private readonly IElectionDayRepository _repository;
        public ElectionDayService(IElectionDayRepository repository)
        {
            _repository = repository;
        }

        public IList<ElectionResGeneral> LastUpdate(ElectionDayParams electionDayParams)
        {
            using (_repository)
            {
                if (electionDayParams.Region != 0)
                    return LastUpdateRegion(electionDayParams);
                
                
                if (electionDayParams.District > 0)
                    return LastUpdateDistrict(electionDayParams);


                if (String.IsNullOrEmpty(electionDayParams.Global) == false)
                    return LastUpdateGlobal(electionDayParams);

                return null;
            }
        }

        public CatalogsDistrictRes CatalogsDistrict()
        {
            var catalogDistric = new CatalogsDistrictRes();
            using (_repository)
            {
                catalogDistric.Regions = _repository.GetRegions();
                catalogDistric.CoordRegions = _repository.GetCoordRegions();
                catalogDistric.LocRegions = _repository.GetLocRegions();
                return catalogDistric;
            }
        }

        public CatalogsDistrictRes CatalogsRegion()
        {
            var catalogDistric = new CatalogsDistrictRes();
            using (_repository)
            {
                catalogDistric.Incidents = _repository.GetIncidents();
                catalogDistric.CoordRegions = _repository.GetCoordRegions();
                catalogDistric.LocRegions = _repository.GetLocRegions();
                return catalogDistric;
            }
        }

        public CatalogsDistrictRes CatalogsDistrictByRegionId(int regionId)
        {
            var catalogDistric = new CatalogsDistrictRes();
            using (_repository)
            {
                catalogDistric.Regions = _repository.GetRegionsByRegionId(regionId);
                catalogDistric.CoordRegions = _repository.GetCoordRegionsByRegionId(regionId);
                catalogDistric.LocRegions = _repository.GetLocRegionsByRegionId(regionId);
                catalogDistric.Incidents = _repository.GetIncidents();
                return catalogDistric;
            }
        }

        private IList<ElectionResGeneral> LastUpdateRegion(ElectionDayParams electionDayParams)
        {
            return _repository.LastUpdateRegion(electionDayParams);
        }

        private IList<ElectionResGeneral> LastUpdateDistrict(ElectionDayParams electionDayParams)
        {
            return _repository.LastUpdateDistrict(electionDayParams);
        }

        private IList<ElectionResGeneral> LastUpdateGlobal(ElectionDayParams electionDayParams)
        {
            return _repository.LastUpdateGlobal(electionDayParams);
        }
    }
}