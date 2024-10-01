using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class TrainTripRout
    {
        public string TrainNo { get; set; }
        public string StationCode { get; set; }
        public System.DateTime ArrivalTime { get; set; }
        public System.DateTime DeptTime { get; set; }
        public Nullable<double> OrderNumber { get; set; }
        public string PlateformNo { get; set; }
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }

        // public Train_Trip Train_Trip { get; set; }
        public station Station { get; set; }
    }
}
