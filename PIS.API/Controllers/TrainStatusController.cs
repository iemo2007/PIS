using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS.Application;
using PIS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStatusController : ControllerBase
    {
        private readonly TrainStatusManager _trainStatusManager;

        public TrainStatusController(TrainStatusManager trainStatusManager)
        {
            _trainStatusManager = trainStatusManager;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("[action]")]
        public ActionResult<List<TrainStatusViewModel>> GetAll()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            List<TrainStatusViewModel> _allTrainStauses = _trainStatusManager.GetAllTrainStatuses()
                .OrderBy(ts => ts.StatusName)
                .ToList();

            return Ok(_allTrainStauses);
        }

        [HttpPost("[action]")]
        public ActionResult AddEditTrainStatus(TrainStatusViewModel model)
        {
            _trainStatusManager.AddEdit(model);
            return Ok();
        }

        [HttpDelete("[action]/{statusID:int}")]
        public ActionResult DeleteTrainStatus(int statusID) 
        {
            _trainStatusManager.DeleteTrainStatus(statusID);
            return Ok();
        }
    }
}
