using PIS.DAL;
using PIS.DAL.Repositories.ScheduleRepo;
using PIS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class ScheduleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<TrainScheduleViewMode> GetTrainsOfToday(int count, string stationCode, DateTime trainsDay, string dayOfTheWeek)
        {
            List<TrainScheduleViewMode> trainsOfToday = _unitOfWork.Schedules.GetTrainsOfToday(count, stationCode, trainsDay, dayOfTheWeek).ToList();
            return trainsOfToday;
        }
    }
}
