using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class Class
    {
        #nullable disable
        public Class()
        {
            Class1TrainTrips = new List<Train_Trip>();
            Class2TrainTrips = new List<Train_Trip>();
        }
        public string ClassCode { get; set; }
        public string ClassEName { get; set; }
        public string ClassAName { get; set; }
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }

        public List<Train_Trip> Class1TrainTrips { get; set; }
        public List<Train_Trip> Class2TrainTrips { get; set; }

    }
}
