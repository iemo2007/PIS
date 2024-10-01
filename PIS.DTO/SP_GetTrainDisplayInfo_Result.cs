using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class SP_GetTrainDisplayInfo_Result
    {
        public string TrainNo { get; set; }
        public string StationCode { get; set; }
        public string NameArb { get; set; }
        public System.DateTime ArrivalTime { get; set; }
        public System.DateTime DeptTime { get; set; }
        public Nullable<double> OrderNumber { get; set; }
        public string PlateformNo { get; set; }
        public string TrainType { get; set; }
        public string ClassCode1 { get; set; }
        public string ClassCode2 { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }

        public string ClassAName1 { get; set; }
        public string ClassAName2 { get; set; }
        public string TrainTypeName { get; set; }
    }
}

