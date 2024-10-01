using Helper;
using Microsoft.EntityFrameworkCore;
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
    public class StationRepository : Repository<station>, IStationRepository
    {
        public PISContext _context { get; }
        public StationRepository(PISContext context) : base(context)
        {
            _context = context;
        }

        public PaginatedStations GetAllStations(int page, int limit, string search, string sort, string order)
        {
            IQueryable<station> allStations = _context.stations.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allStations = allStations
                    .Where(s => (!string.IsNullOrWhiteSpace(s.StationCode) && s.StationCode.ToLower().Contains(search))
                    || (!string.IsNullOrWhiteSpace(s.NameArb) && s.NameArb.Contains(search))
                    || (!string.IsNullOrWhiteSpace(s.NameEngl) && s.NameEngl.ToLower().Contains(search.ToLower())));
            }

            allStations = Helpers.OrderBy(allStations, sort ?? nameof(StationsViewModel.NameArb), order);
            int total = allStations.Count();
            allStations = allStations.Skip((page-1)*limit).Take(limit);
            
            List<StationsViewModel> stations = allStations.Select(_station => new StationsViewModel
            {
                NameArb = _station.NameArb,
                NameEngl = _station.NameEngl,
                StationCode = _station.StationCode.Trim(),
                LastModified = _station.LastModified
            }).ToList();

            PaginatedStations paginatedStations = new PaginatedStations
            {
                Total = stations.Count(),
                Stations = stations
            };
            
            return paginatedStations;
        }
    }
}
