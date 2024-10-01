using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class TrainScheduleSearchFilter
    {
        public string TrainNo { get; set; }
        public string DepartureTime { get; set; }
        public string EndPlatformNumber { get; set; }
        public string ArrivalTime { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public string CurrentStation { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
