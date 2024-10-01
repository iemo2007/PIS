using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    #nullable disable
    public class Train_Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusSymbol { get; set; }
        public string StatusEnSymbol { get; set; }
        public System.DateTime LastModified { get; set; }
        public Nullable<System.DateTime> audDateLastChanged { get; set; }
    }
}
