using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DTO.RequestDTO
{
    public class UpdateTrainsTripRoutesRequest
    {
        public List<TrainsTripRouteDTO> TrainStations { get; set; }
    }
}
