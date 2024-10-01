using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class CreateNewTrainDTO
    {
        public string TrainNo { get; set; }
        public string StartStationCode { get; set; }
        public string StartStationName { get; set; }
        public string EndStationCode { get; set; }
        public string EndStationName { get; set; }
        public string StartPlatformNumber { get; set; }
        public string EndPlatformNumber { get; set; }
        public bool HasNoStartPlatForm { get; set; }
        public string PlatformNumber { get; set; }
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Order { get; set; }
    }
}
