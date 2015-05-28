using System;
using System.Collections.Generic;
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

        public IList<string> LastResult(int candidateType)
        {
            throw new NotImplementedException();
            //using (_prepRepository)
            //{
                
            //}
        }
    }
}