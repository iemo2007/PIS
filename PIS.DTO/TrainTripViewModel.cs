using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PIS.DTO
{
    public class TrainTripViewModel
    {
        public string TrainNo { get; set; }
        public string StartStationCode { get; set; }
        public string StartStationName { get; set; }
        public IEnumerable<StationsViewModel> StartStations { get; set; }
        public string EndStationCode { get; set; }
        public string EndStationName { get; set; }
        public IEnumerable<StationsViewModel> EndStations { get; set; }
        public string StartPlatformNumber { get; set; } = "1";
        public string EndPlatformNumber { get; set; } = "1";
        public bool HasNoStartPlatForm { get; set; }
        public bool HasNoEndPlatForm { get; set; }
        public string PlatformNumber { get; set; }
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Order { get; set; }
    }
}
