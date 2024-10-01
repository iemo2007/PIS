using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO
{
    public class TrainTypeViewModel
    {
        public string TrainType { get; set; }
        public string TrainTypeDescEngl { get; set; }
        public string TrainTypeDescArb { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? audDateLastChanged { get; set; }
    }
}
