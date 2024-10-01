using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS.Application;
using PIS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainDelayReasonController : ControllerBase
    {
        private readonly TrainDelayReasonManager _trainDelayReasonManager;

        public TrainDelayReasonController(TrainDelayReasonManager trainDelayReasonManager)
        {
            _trainDelayReasonManager = trainDelayReasonManager;
        }

        [HttpGet("[action]")]
        public ActionResult<List<TrainDelayReasonViewModel>> GetAllTrainDelayReasons()
        {
            List<TrainDelayReasonViewModel> _allTrainStauses = _trainDelayReasonManager.GetAllTrainDelayReasons()
                .OrderBy(x => x.ResonName)
                .ToList();
            return Ok(_allTrainStauses);
        }

        [HttpPost("[action]")]
        public ActionResult AddEditDelayReason(TrainDelayReasonViewModel model)
        {
            _trainDelayReasonManager.AddEditDelayReason(model);
            return Ok();
        }

        [HttpDelete("[action]/{resonID:int}")]
        public ActionResult DeleteDelayReason(int resonID)
        {
            _trainDelayReasonManager.DeleteDelayReason(resonID);
            return Ok();
        }
    }
}
