using PIS.DAL.Repositories.ClassRepo;
using PIS.DAL.Repositories.ScheduleRepo;
using PIS.DAL.Repositories.StationRepo;
using PIS.DAL.Repositories.Train_Delay_ResonRepo;
using PIS.DAL.Repositories.Train_StatusRepo;
using PIS.DAL.Repositories.Train_TripRepo;
using PIS.DAL.Repositories.Train_TypeRepo;
using PIS.DAL.Repositories.TrainTripRoutRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRepository Classes { get; }
        IScheduleRepository Schedules { get; }
        IStationRepository stations { get; }
        ITrain_Delay_ResonRepository Train_Delay_Reson { get; }
        ITrain_StatusRepository Train_Status { get; }
        ITrain_TripRepository Train_Trip { get; }
        ITrain_TypeRepository Train_Type { get; }
        ITrainTripRoutRepository TrainTripRouts { get; }
        bool Complete();
    }
}
