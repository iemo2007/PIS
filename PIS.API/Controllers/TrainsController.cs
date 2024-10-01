using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DTO;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly TrainScheduleManager _trainScheduleManager;
        private readonly TrainTripManager _trainTripManager;

        public TrainsController(TrainScheduleManager trainScheduleManager, TrainTripManager trainTripManager)
        {
            _trainScheduleManager = trainScheduleManager;
            _trainTripManager = trainTripManager;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create(CreateNewTrainDTO objTrain)
        {
            string strCurrentStation = "108"; // UserSession.CurrentUser.StationCode;
            var model = new TrainScheduleViewMode
            {
                TrainNo = objTrain.TrainNo,
                ArrivalTime = objTrain.ArrivalTime,
                DeptTime = objTrain.DepartureTime,
                StartStationCode = objTrain.StartStationCode,
                FinalStationCode = objTrain.EndStationCode,
                A_Journy = objTrain.StartStationName + " - " + objTrain.EndStationName,
                PlateformNo = objTrain.PlatformNumber
            };
            _trainScheduleManager.AddUpdateTrainSchedule2(model, strCurrentStation);
            return Ok();
            //TrainTripViewModel newObj = new TrainTripViewModel();
            //IncludeStations(newObj);
            //return View(newObj);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<TrainDisplayInfoViewModel> GetTrainTripDetails(string id)
        {

            TrainDisplayInfoViewModel model = _trainTripManager.GetDisplayTrainInfo(id);
            return Ok(model);
        }

        [HttpPost("[action]")]
        public ActionResult UpdateTrainTripDetails(UpdateTrainTripRequest model)
        {
            string strCurrentStation = "108"; // UserSession.CurrentUser.StationCode;
            _trainTripManager.UpdateTrainTrip(model, strCurrentStation);
            return Ok();
        }
    }
}
