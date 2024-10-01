using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class Train_Delay_Reson
    {
        public int ResonID { get; set; }
        public string ResonName { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
    }
}
