using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DTO;
using System.Collections.Generic;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTimesController : ControllerBase
    {
        private readonly TrainTripManager _trainTripManager;

        public TrainTimesController(TrainTripManager trainTripManager)
        {
            _trainTripManager = trainTripManager;
        }

        [HttpGet("[action]/{TrainNo}")]
        public ActionResult<List<TrainDisplayInfoViewModel>> SearchTrain(string TrainNo)
        {
            string userStationCode = "108";

            List<TrainDisplayInfoViewModel> res = _trainTripManager.GetTrainTimes(TrainNo, userStationCode);
            return Ok(res);
        }

        [HttpDelete]
        public ActionResult DeleteTrainTime(string trainNo, string startStation, string finalStation)
        {
            _trainTripManager.DeleteTrainTime(trainNo.Trim(), startStation.Trim(), finalStation.Trim());
            return Ok();
        }
    }
}
