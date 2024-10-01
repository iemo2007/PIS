using Microsoft.EntityFrameworkCore.Storage;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PISContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(PISContext context)
        {
            _context = context;
            Classes = new ClassRepository(_context);
            Schedules = new ScheduleRepository(_context);
            stations = new StationRepository(_context);
            Train_Delay_Reson = new Train_Delay_ResonRepository(_context);
            Train_Status = new Train_StatusRepository(_context);
            Train_Trip = new Train_TripRepository(_context);
            Train_Type = new Train_TypeRepository(_context);
            TrainTripRouts = new TrainTripRoutRepository(_context);
        }

        public IClassRepository Classes { get; private set; }
        public IScheduleRepository Schedules { get; private set; }
        public IStationRepository stations { get; private set; }
        public ITrain_Delay_ResonRepository Train_Delay_Reson { get; private set; }
        public ITrain_StatusRepository Train_Status { get; private set; }
        public ITrain_TripRepository Train_Trip { get; private set; }
        public ITrain_TypeRepository Train_Type { get; private set; }
        public ITrainTripRoutRepository TrainTripRouts { get; private set; }

        public bool Complete()
        {
            return (_context.SaveChanges() == 1);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
