using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DTO;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTripRoutController : ControllerBase
    {
        private readonly TrainTripRoutManager _trainTripRoutManager;

        public TrainTripRoutController(TrainTripRoutManager trainTripRoutManager)
        {
            _trainTripRoutManager = trainTripRoutManager;
        }
        [HttpGet("[action]")]
        public ActionResult<TrainDisplayInfoViewModel> GetDisplayTrainInfo()
        {
            string userStationCode = "10";
            // TrainDisplayInfoViewModel res = _trainTripRoutManager.GetDisplayTrainInfo(userStationCode);
            //return Ok(res);
            return Ok();
        }
    }
}
