using Microsoft.EntityFrameworkCore;
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
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public PISContext _context { get; }
        public ScheduleRepository(PISContext context) : base(context)
        {
            _context = context;
        }

        public List<TrainScheduleViewMode> GetTrainsOfToday(Nullable<int> count, string stationCode, DateTime trains_Day, string dayOfWeek)
        {
            List<string> days = new List<string> { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            List<TrainScheduleViewMode> trainsOfToday = _context.Schedules
                .Where(s => s.CurrentStation == stationCode &&
                (s.ArrivalTime.Value.TimeOfDay >= trains_Day.TimeOfDay || s.DeptTime.Value.TimeOfDay >= trains_Day.TimeOfDay) &&
                days.Contains(dayOfWeek))
                .OrderBy(s => s.DeptTime)
                .Take(count ?? 10)
                .Select(s => new TrainScheduleViewMode
                {
                    TrainNo = s.TrainNo,
                    ArrivalTime = s.ArrivalTime.Value.ToString("HH:mm"),
                    DeptTime = s.DeptTime.Value.ToString("HH:mm"),
                    A_Journy = s.A_Journy,
                    Class1AName = s.Class1AName,
                    Class0AName = s.Class0AName,
                    TrainTypeAName = s.TrainTypeAName,
                    PlateformNo = s.PlateformNo,
                    DelayStatus = s.DelayStatus,
                    CurrentStation = stationCode,
                })
                .ToList();
            return trainsOfToday;
        }

        public List<TrainScheduleViewMode> GetAllTrainSchedules()
        {
            var query = from schedule in _context.Schedules
                        join trainTripRout in _context.TrainTripRouts
                        on schedule.TrainNo equals trainTripRout.TrainNo
                        select new TrainScheduleViewMode
                        {
                            TrainNo = schedule.TrainNo,
                            ArrivalTime = schedule.ArrivalTime.HasValue ? schedule.ArrivalTime.Value.ToString("HH:mm:ss") : "",
                            audDateLastChanged = schedule.audDateLastChanged,
                            A_Journy = schedule.A_Journy,
                            Class0AName = schedule.Class0AName,
                            Class0Code = schedule.Class0Code,
                            Class0EName = schedule.Class0EName,
                            Class1AName = schedule.Class1AName,
                            Class1Code = schedule.Class1Code,
                            Class1EName = schedule.Class1EName,
                            CurrentStation = schedule.CurrentStation,
                            DelayStatus = schedule.DelayStatus,
                            DeptTime = schedule.DeptTime.HasValue ? schedule.DeptTime.Value.ToString("HH:mm:ss") : "",
                            E_Journy = schedule.E_Journy,
                            FinalStationCode = schedule.FinalStationCode,
                            Friday = schedule.Friday,
                            Modified = schedule.Modified,
                            Monday = schedule.Monday,
                            PlateformNo = schedule.PlateformNo,
                            Saturday = schedule.Saturday,
                            StartStationCode = schedule.StartStationCode,
                            StationOrder = schedule.StationOrder,
                            Sunday = schedule.Sunday,
                            Thursday = schedule.Thursday,
                            TrainTypeAName = schedule.TrainTypeAName,
                            TrainTypeCode = schedule.TrainTypeCode,
                            TrainTypeEName = schedule.TrainTypeEName,
                            Tuesday = schedule.Tuesday,
                            Wednesday = schedule.Wednesday,
                            DelayReason = schedule.DelayReason,
                            OrignalArrivalTime = trainTripRout.ArrivalTime.ToString("HH:mm:ss"),
                            OrignalDepatruteTime = trainTripRout.DeptTime.ToString("HH:mm:ss")
                        };

            return query.ToList();
        }
    }
}
