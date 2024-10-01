using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DTO;
using PIS.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace PIS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainOfTodayController : ControllerBase
    {
        private readonly ScheduleManager _scheduleManager;

        public TrainOfTodayController(ScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("[action]")]
        public ActionResult<TrainScheduleViewMode> SearchTrain(SearchTrainRequest request)
        {
            var station = HttpContext.Items["Station"]?.ToString();

            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email == null)
            {
                return Unauthorized();
            }
            string userStationCode = "108";
            string today = DateTime.Now.DayOfWeek.ToString();
            List<TrainScheduleViewMode> trainsOfToday = _scheduleManager.GetTrainsOfToday(request.NumberOfTrains, userStationCode, request.TimeForTrains, today);
            return Ok(trainsOfToday);
        }
    }
}
