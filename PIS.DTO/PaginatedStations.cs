using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class PaginatedStations
    {
        public int Total { get; set; }
        public List<StationsViewModel> Stations { get; set; }
    }
}
