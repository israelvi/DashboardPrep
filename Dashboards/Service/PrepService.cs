using System;
using System.Collections.Generic;
using Dashboards.Models;
using Dashboards.Repository;

namespace Dashboards.Service
{
    public class PrepService : IPrepService
    {
        private readonly IPrepRepository _prepRepository;

        public PrepService(IPrepRepository prepRepository)
        {
            _prepRepository = prepRepository;
        }

        public IList<EleccionesDto> LastResult(int candidateType)
        {
            using (_prepRepository)
            {
                return _prepRepository.LastResult(candidateType);
            }
        }
    }
}