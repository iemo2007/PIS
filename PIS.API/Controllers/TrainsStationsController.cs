using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DTO;
using PIS.DTO.RequestDTO;
using System.Collections.Generic;
using System.Linq;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsStationsController : ControllerBase
    {
        private readonly TrainTripManager _trainTripManager;

        public TrainsStationsController(TrainTripManager trainTripManager)
        {
            _trainTripManager = trainTripManager;
        }

        [HttpGet("[action]/{trainNo}")]
        public ActionResult<List<TrainsTripRouteDTO>> SearchTrain(string trainNo)
        {
            List<TrainsTripRouteDTO> result = _trainTripManager.GetTrainsTripRoutes(trainNo);
            
            return Ok(result);
        }

        [HttpPost("[action]")]
        public ActionResult SaveTrainStations(UpdateTrainsTripRoutesRequest req)
        {
            if(req.TrainStations == null || !req.TrainStations.Any())
            {
                return BadRequest("لا يوجد محطات لحفظها");
            }

            _trainTripManager.UpdateTrainsTripRoutes(req.TrainStations.FirstOrDefault().TrainNo, req.TrainStations);

            return Ok();
        }
    }
}
