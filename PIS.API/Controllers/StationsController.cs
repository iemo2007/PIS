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
    public class StationsController : ControllerBase
    {
        private readonly StationManager _stationManager;
        private readonly TrainScheduleManager _trainScheduleManager;

        public StationsController(StationManager stationManager, TrainScheduleManager trainScheduleManager)
        {
            _stationManager = stationManager;
            _trainScheduleManager = trainScheduleManager;
        }

        //[HttpPost("[action]")]
        //public ActionResult<PaginatedStations> GetAllStations(GetAllStationsRequest request)
        //{
        //    //PaginatedStations paginatedStations = _stationManager.GetAllStations(request.Page, request.Limit, request.Search, request.Sort, request.Order);
        //    return Ok(/*paginatedStations*/);
        //}

        [HttpGet("[action]")]
        public ActionResult<StationsViewModel> GetAllStations()
        {
            List<StationsViewModel> stations = _stationManager.GetAllStations();
            return Ok(stations);
        }

        [HttpPost("[action]")]
        public ActionResult<TrainScheduleViewMode> SearchTrain(TrainScheduleSearchFilter searchFilter)
        {
            searchFilter.CurrentStation = "108";// UserSession.CurrentUser.StationCode;
            List<TrainScheduleViewMode> result =
                _trainScheduleManager.SearhTrainSchedules(searchFilter)
                .Distinct()
                .ToList();

            //if (searchFilter.Sort == null)
            //    result = result.OrderBy(sts => sts.TrainNo).ToList();
            //else
            //    result = result.OrderBy(sts => searchFilter.Order).ToList();

            //var model = new
            //{
            //    total = result.Count(),
            //    rows = result.Skip((searchFilter.Offset / searchFilter.Limit) * searchFilter.Limit).Take(searchFilter.Limit)
            //};
            return Ok(result);
        }
    }
}
