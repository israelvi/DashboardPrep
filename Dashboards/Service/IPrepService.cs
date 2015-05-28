using System.Collections.Generic;

namespace Dashboards.Service
{
    public interface IPrepService
    {
        IList<string> LastResult(int candidateType);
    }
}
