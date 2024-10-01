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
    public class TrainScheduleViewMode
    {
        public string TrainNo { get; set; }
        public string CurrentStation { get; set; }
        public string ArrivalTime { get; set; }
        public string DeptTime { get; set; }

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
        public string DelayReason { get; set; }
        public bool WithoutPlatform
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PlateformNo) || PlateformNo.Trim() == "-" || PlateformNo.Trim() == "_")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public double? StationOrder { get; set; }
        public bool Modified { get; set; }
        public DateTime? audDateLastChanged { get; set; }
        public bool IsNew { set; get; }
        public string OrignalDepatruteTime { get; set; }
        public string OrignalArrivalTime { get; set; }
    }
}
