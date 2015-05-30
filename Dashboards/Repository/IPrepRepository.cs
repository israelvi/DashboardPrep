using System;
using System.Collections.Generic;
using Dashboards.Models;

namespace Dashboards.Repository
{
    public interface IPrepRepository : IDisposable
    {
        IList<EleccionesDto> LastResult(int candidateType);
    }
}