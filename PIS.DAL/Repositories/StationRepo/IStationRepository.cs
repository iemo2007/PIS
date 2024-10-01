using PIS.DAL.Repositories.GenericRepo;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.StationRepo
{
    public interface IStationRepository : IRepository<station>
    {
        public PaginatedStations GetAllStations(int page, int limit, string search, string sort, string order);
    }
}
