using PIS.DAL.Repositories.GenericRepo;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.Train_TripRepo
{
    public interface ITrain_TripRepository : IRepository<Train_Trip>
    {
        public List<SP_GetTrainDisplayInfo_Result> SP_GetTrainDisplayInfo(string trainNo);
        void ResetTrainTripTableTrainNumber(string trainNo);
        public void ResetTrainTripTable(string trainNo);
        public void InsertIntoTrainTrip(string trainNo);
        public void InsertIntoSchedule(string trainNo);
    }
}
