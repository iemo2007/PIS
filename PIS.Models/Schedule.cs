using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class Schedule
    {
        public string TrainNo { get; set; }
        public string CurrentStation { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
        public Nullable<System.DateTime> DeptTime { get; set; }
        public string StartStationCode { get; set; }
        public string FinalStationCode { get; set; }
        public string E_Journy { get; set; }
        public string A_Journy { get; set; }
        public string Class0Code { get; set; }
        public string Class0EName { get; set; }
        public string Class0AName { get; set; }
        public string Class1Code { get; set; }
        public string Class1EName { get; set; }
        public string Class1AName { get; set; }
        public string TrainTypeCode { get; set; }
        public string TrainTypeEName { get; set; }
        public string TrainTypeAName { get; set; }
        public string PlateformNo { get; set; }
        public string DelayStatus { get; set; }
        public Nullable<bool> Saturday { get; set; }
        public Nullable<bool> Sunday { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Tuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
        public Nullable<double> StationOrder { get; set; }
        public bool Modified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
        public string DelayReason { get; set; }

        // public Train_Trip TrainTrip { get; set; }
        public station Station { get; set; }
    }
}
