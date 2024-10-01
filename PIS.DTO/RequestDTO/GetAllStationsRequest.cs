using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO.RequestDTO
{
    public class GetAllStationsRequest
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
