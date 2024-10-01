using PIS.DAL.Repositories.GenericRepo;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.ScheduleRepo
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        List<TrainScheduleViewMode> GetTrainsOfToday(Nullable<int> count, string stationCode, DateTime trains_Day, string dayOfWeek);
        List<TrainScheduleViewMode> GetAllTrainSchedules();
    }
}
