using System.Collections.Generic;

namespace Dashboards.Models.Dto
{
    public class CatalogsDistrictRes
    {
        public IList<ItemModel> Regions { get; set; }
        public IList<ItemModel> CoordRegions { get; set; }
        public IList<ItemModel> LocRegions { get; set; }
        public IList<ItemModel> Incidents { get; set; }
    }
}