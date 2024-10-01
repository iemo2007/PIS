using PIS.DAL;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class StationManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public StationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public PaginatedStations GetAllStations(int page, int limit, string search, string sort, string order)
        //{
        //    PaginatedStations paginatedStations = _unitOfWork.stations.GetAllStations(page, limit, search, sort, order);
        //    return paginatedStations;
        //}

        public List<StationsViewModel> GetAllStations()
        {
            return _unitOfWork.stations.GetAll().Select(_station => new StationsViewModel
            {
                NameArb = _station.NameArb,
                NameEngl = _station.NameEngl,
                StationCode = _station.StationCode.Trim(),
                LastModified = _station.LastModified
            }).Distinct().ToList();
        }

        public StationsViewModel GetStation(string stationCode)
        {
            var _station = _unitOfWork.stations.FilterFirst(s => s.StationCode.Trim() == stationCode.Trim());
            if (_station != null)
            {
                return new StationsViewModel
                {
                    NameArb = _station.NameArb,
                    NameEngl = _station.NameEngl,
                    StationCode = _station.StationCode.Trim(),
                    LastModified = _station.LastModified
                };
            }
            else return null;
        }

        public string AddStation(StationsViewModel objStation)
        {
            station objNewStation = new station()
            {
                NameArb = objStation.NameArb,
                NameEngl = objStation.NameEngl,
                LastModified = DateTime.Now,
                audDateLastChanged = DateTime.Now,
                StationCode = getNewStationCode()

            };

            _unitOfWork.stations.Add(objNewStation);
            var added = _unitOfWork.Complete();
            if (added) return objNewStation.StationCode;
            else return null;
        }

        public string UpdateStation(StationsViewModel objStation)
        {
            var objStationToUpdate = _unitOfWork.stations.FilterFirst(s => s.StationCode.Trim() == objStation.StationCode.Trim());

            if (objStationToUpdate == null)
            {
                return null;
            }


            objStationToUpdate.NameArb = objStation.NameArb;
            objStationToUpdate.NameEngl = objStation.NameEngl;
            objStationToUpdate.LastModified = DateTime.Now;
            objStationToUpdate.audDateLastChanged = DateTime.Now;


            _unitOfWork.stations.update(objStationToUpdate);
            var updated = _unitOfWork.Complete();
            if (updated) return objStationToUpdate.StationCode;
            else return null;
        }

        public bool DeleteStation(StationsViewModel objStation)
        {
            var objStationToUpdate = _unitOfWork.stations.FilterFirst(s => s.StationCode.Trim() == objStation.StationCode.Trim());

            if (objStationToUpdate == null)
            {
                return false;
            }
            _unitOfWork.stations.Delete(objStationToUpdate);
            bool isDeleted = _unitOfWork.Complete();
            return isDeleted;

        }
        private string getNewStationCode()
        {
            var myVar = _unitOfWork.stations.GetAll().AsEnumerable().Max(x => int.Parse(x.StationCode.Trim()));
            return (++myVar).ToString();
        }
    }
}
