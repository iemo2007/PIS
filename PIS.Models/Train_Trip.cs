using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class Train_Trip
    {
        public Train_Trip()
        {
            // TrainTripRouts = new List<TrainTripRout>();
            // Schedules = new List<Schedule>();
        }
        public string TrainNo { get; set; }
        //public string StartStation 
        //{ 
        //    get
        //    {
        //        var srartStaion = TrainTripRouts.FirstOrDefault(ttr => ttr.OrderNumber == 1);
        //        if (srartStaion != null) 
        //        {
        //            return srartStaion.StationCode;
        //        }
        //        return string.Empty;
        //    }
        //}
        public string StartStation { get; set; }
        public System.DateTime DepartureTime { get; set; }
        //{
        //    get
        //    {
        //        var srartStaion = TrainTripRouts.FirstOrDefault(ttr => ttr.OrderNumber == 1);
        //        if (srartStaion != null)
        //        {
        //            return srartStaion.DeptTime;
        //        }
        //        return DateTime.MinValue;
        //    }
        //}



        //public string FinalStation
        //{
        //    get
        //    {
        //        var finalStaion = TrainTripRouts.OrderByDescending(ttr => ttr.OrderNumber).FirstOrDefault();
        //        if (finalStaion != null)
        //        {
        //            return finalStaion.StationCode;
        //        }
        //        return string.Empty;
        //    }
        //}
        public string FinalStation { get; set; }
        public System.DateTime ArrivalTime { get; set; }
        //{
        //    get
        //    {
        //        var finalStaion = TrainTripRouts.OrderByDescending(ttr => ttr.OrderNumber).FirstOrDefault();
        //        if (finalStaion != null)
        //        {
        //            return finalStaion.ArrivalTime;
        //        }
        //        return DateTime.MinValue;
        //    }
        //}
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
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }

        public Class Class1 { get; set; }
        public Class Class2 { get; set; }
        public station StartStationObj { get; set; }
        public station FinalStationObj { get; set; }
        public Train_Type Train_Type { get; set; }

        // public List<TrainTripRout> TrainTripRouts { get; set; }
        // public List<Schedule> Schedules { get; set; }
    }
}
