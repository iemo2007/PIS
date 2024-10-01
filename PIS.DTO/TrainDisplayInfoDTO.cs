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
    public class TrainDisplayInfoDTO
    {
        public string StationCode { get; set; }
        public string NameArb { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DeptTime { get; set; }
        public double? OrderNumber { get; set; }
        public string PlateformNo { get; set; }


        //////////////

        public string TrainNo { get; set; }
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
        public string TripNameArb { get; set; }
        public string TripNameEn { get; set; }
        public string StartStation { get; set; }
        public string FinalStation { get; set; }

        public string ClassAName1 { get; set; }
        public string ClassAName2 { get; set; }
    }
}
