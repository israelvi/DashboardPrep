using System.Collections.Generic;
using Dashboards.Models;

namespace Dashboards.Service
{
    public interface IPrepService
    {
        IList<EleccionesDto> LastResult(int candidateType);
    }
}
