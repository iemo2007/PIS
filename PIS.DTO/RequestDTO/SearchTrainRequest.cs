using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO.RequestDTO
{
    public class SearchTrainRequest
    {
        public DateTime TimeForTrains { get; set; }
        public int NumberOfTrains { get; set; }
    }
}
