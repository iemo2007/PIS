using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class Train_Type
    {
        public Train_Type()
        {
            TrainTrips = new List<Train_Trip>();
        }
        public string TrainType { get; set; }
        public string TrainTypeDescEngl { get; set; }
        public string TrainTypeDescArb { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
        public List<Train_Trip> TrainTrips { get; set; }
    }
}
