using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class station
    {
        #nullable disable
        public station()
        {
            TrainTripRouts = new List<TrainTripRout>();
            Schedules= new List<Schedule>();
        }
        public string StationCode { get; set; }
        public string NameArb { get; set; }
        public string NameEngl { get; set; }
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
        public List<Train_Trip> TrainTripsStart { get; set; }
        public List<Train_Trip> TrainTripsFinal { get; set; }
        public List<TrainTripRout> TrainTripRouts { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
