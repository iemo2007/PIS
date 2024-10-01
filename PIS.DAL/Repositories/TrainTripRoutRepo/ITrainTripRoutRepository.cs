using PIS.DAL.Repositories.GenericRepo;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.TrainTripRoutRepo
{
    public interface ITrainTripRoutRepository : IRepository<TrainTripRout>
    {
        public TrainDisplayInfoViewModel GetDisplayTrainInfo(string strTrainNo);
        public List<TrainDisplayInfoViewModel> SP_GetTrainTimes(string trainNo, string stationCode);
    }
}
