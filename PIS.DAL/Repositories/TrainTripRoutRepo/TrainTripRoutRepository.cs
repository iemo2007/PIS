using Microsoft.EntityFrameworkCore;
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
    public class TrainTripRoutRepository : Repository<TrainTripRout>, ITrainTripRoutRepository
    {
        public PISContext _context { get; }
        public TrainTripRoutRepository(PISContext context) : base(context)
        {
            _context = context;
        }

        public TrainDisplayInfoViewModel GetDisplayTrainInfo(string strTrainNo)
        {
            //List<TrainDisplayInfoDTO> trainDisplayInfo = _context.TrainTripRouts.Where(ttr => ttr.TrainNo == strTrainNo)
            //    .Select(ttr => new TrainDisplayInfoDTO 
            //    {
            //        TrainNo = ttr.TrainNo,
            //        StationCode= ttr.StationCode,
            //        NameArb = ttr.Station.NameArb,
            //        ArrivalTime = ttr.ArrivalTime,
            //        DeptTime= ttr.DeptTime,
            //        OrderNumber= ttr.OrderNumber,
            //        PlateformNo = ttr.PlateformNo,
            //        TrainType =ttr.Train_Trip.TrainType,
            //        ClassCode1 = ttr.Train_Trip.ClassCode1,
            //        ClassCode2 = ttr.Train_Trip.ClassCode2,
            //        Saturday = ttr.Train_Trip.Saturday,
            //        Sunday = ttr.Train_Trip.Sunday,
            //        Monday = ttr.Train_Trip.Monday,
            //        Tuesday = ttr.Train_Trip.Tuesday,
            //        Wednesday = ttr.Train_Trip.Wednesday,
            //        Thursday = ttr.Train_Trip.Thursday,
            //        Friday = ttr.Train_Trip.Friday,
            //    })
            //    .ToList();
            //return trainDisplayInfo;


            var result = (from trip in _context.Train_Trip
                          join route in _context.TrainTripRouts on trip.TrainNo equals route.TrainNo
                          join station in _context.stations on route.StationCode equals station.StationCode
                          join trainClass in _context.Classes on trip.ClassCode1 equals trainClass.ClassCode
                          join trainClass2 in _context.Classes on trip.ClassCode2 equals trainClass2.ClassCode
                          join trainType in _context.Train_Type on trip.TrainType equals trainType.TrainType
                          where trip.TrainNo == strTrainNo
                          orderby route.OrderNumber
                          group new { trip, route, station, trainClass, trainClass2, trainType } by new
                          {
                              trip.TrainNo,
                              trip.TrainType,
                              trip.ClassCode1,
                              trip.ClassCode2,
                              trip.Saturday,
                              trip.Sunday,
                              trip.Monday,
                              trip.Tuesday,
                              trip.Wednesday,
                              trip.Thursday,
                              trip.Friday,
                              trainClass.ClassAName,
                              Class2AName = trainClass2.ClassAName,
                              TrainTypeName = trainType.TrainTypeDescArb
                          } into grouped
                          select new TrainDisplayInfoViewModel
                          {
                              TrainNo = grouped.Key.TrainNo,
                              TrainType = grouped.Key.TrainType,
                              ClassCode1 = grouped.Key.ClassCode1,
                              ClassCode2 = grouped.Key.ClassCode2,
                              Saturday = grouped.Key.Saturday,
                              Sunday = grouped.Key.Sunday,
                              Monday = grouped.Key.Monday,
                              Tuesday = grouped.Key.Tuesday,
                              Wednesday = grouped.Key.Wednesday,
                              Thursday = grouped.Key.Thursday,
                              Friday = grouped.Key.Friday,
                              ClassAName1 = grouped.Key.ClassAName,
                              ClassAName2 = grouped.Key.Class2AName,
                              TrainTypeName =grouped.Key.TrainTypeName,
                              TrainDisplayInfoDetails = grouped.Select(g => new TrainDisplayInfoDetailsViewModel
                              {
                                  StationCode = g.route.StationCode,
                                  NameArb = g.station.NameArb,
                                  ArrivalTime = g.route.ArrivalTime,
                                  DeptTime = g.route.DeptTime,
                                  OrderNumber = g.route.OrderNumber,
                                  PlateformNo = g.route.PlateformNo
                              }).ToList()
                          }).FirstOrDefault();

            return result;
        }

        public List<TrainDisplayInfoViewModel> SP_GetTrainTimes(string trainNo, string stationCode)
        {
            //IQueryable<TrainTripRout> trainTripRouts = _context.TrainTripRouts.AsQueryable();
            //if (stationCode != "0")
            //{
            //    trainTripRouts = trainTripRouts.Where(ttr => ttr.StationCode == stationCode);
            //}

            //List<TrainDisplayInfoViewModel> trainsInfo = trainTripRouts.Where(ttr => stationCode.Contains(ttr.Train_Trip.TrainNo))
            //    .Select(ttr => new TrainDisplayInfoViewModel
            //    {
            //        TrainNo = ttr.TrainNo,
            //        ClassCode1 = ttr.Train_Trip.ClassCode1,
            //        ClassCode2 = ttr.Train_Trip.ClassCode2,
            //        TripNameArb = $"{ttr.Train_Trip.StartStationObj.NameArb} - {ttr.Train_Trip.FinalStationObj.NameArb}",
            //        TripNameEn = $"{ttr.Train_Trip.StartStationObj.NameEngl} - {ttr.Train_Trip.FinalStationObj.NameEngl}",

            //        Friday = ttr.Train_Trip.Friday,
            //        Saturday = ttr.Train_Trip.Saturday,
            //        Sunday = ttr.Train_Trip.Sunday,
            //        Monday = ttr.Train_Trip.Monday,
            //        Tuesday = ttr.Train_Trip.Tuesday,
            //        Wednesday = ttr.Train_Trip.Wednesday,
            //        Thursday = ttr.Train_Trip.Thursday,

            //        TrainType = ttr.Train_Trip.Train_Type.TrainTypeDescArb.Trim(),

            //        StartStation = ttr.Train_Trip.StartStation,
            //        FinalStation = ttr.Train_Trip.FinalStation,
            //        ClassAName1 = ttr.Train_Trip.Class1.ClassAName,
            //        ClassAName2 = ttr.Train_Trip.Class2.ClassAName
            //    })
            //    .ToList();
            //return trainsInfo;

            //var query = from trip in _context.Train_Trip
            //            join route in _context.TrainTripRouts on trip.TrainNo equals route.TrainNo
            //            join trainType in _context.Train_Type on trip.TrainType equals trainType.TrainType
            //            join station1 in _context.stations on trip.StartStation equals station1.StationCode
            //            join station2 in _context.stations on trip.FinalStation equals station2.StationCode
            //            join class1 in _context.Classes on trip.ClassCode1 equals class1.ClassCode
            //            join class2 in _context.Classes on trip.ClassCode2 equals class2.ClassCode
            //            where route.StationCode == stationCode && trip.TrainNo.Contains(trainNo)
            //            select new TrainDisplayInfoViewModel
            //            {
            //                TrainNo = trip.TrainNo,
            //                TrainType = trainType.TrainTypeDescArb,
            //                ClassCode1 = trip.ClassCode1,
            //                ClassCode2 = trip.ClassCode2,
            //                Saturday = trip.Saturday,
            //                Sunday = trip.Sunday,
            //                Monday = trip.Monday,
            //                Tuesday = trip.Tuesday,
            //                Wednesday = trip.Wednesday,
            //                Thursday = trip.Thursday,
            //                Friday = trip.Friday,
            //                TripNameArb = station1.NameArb + " - " + station2.NameArb,
            //                TripNameEn = station1.NameEngl + " - " + station2.NameEngl,
            //                StartStation = trip.StartStation,
            //                FinalStation = trip.FinalStation,
            //                ClassAName1 = class1.ClassAName,
            //                ClassAName2 = class2.ClassAName,
            //                TrainDisplayInfoDetails = _context.TrainTripRouts
            //                    .Where(r => r.TrainNo == trip.TrainNo)
            //                    .Select(r => new TrainDisplayInfoDetailsViewModel
            //                    {
            //                        StationCode = r.StationCode,
            //                        NameArb = _context.stations.FirstOrDefault(s => s.StationCode == r.StationCode).NameArb,
            //                        ArrivalTime = r.ArrivalTime,
            //                        DeptTime = r.DeptTime,
            //                        OrderNumber = r.OrderNumber,
            //                        PlateformNo = r.PlateformNo
            //                    }).ToList()
            //            };

            //var res = query.ToList().Distinct().ToList();
            //return res;


            var query = from trip in _context.Train_Trip
                        join route in _context.TrainTripRouts on trip.TrainNo equals route.TrainNo
                        join trainType in _context.Train_Type on trip.TrainType equals trainType.TrainType
                        join station1 in _context.stations on trip.StartStation equals station1.StationCode
                        join station2 in _context.stations on trip.FinalStation equals station2.StationCode
                        join class1 in _context.Classes on trip.ClassCode1 equals class1.ClassCode
                        join class2 in _context.Classes on trip.ClassCode2 equals class2.ClassCode
                        where route.StationCode == stationCode && trip.TrainNo.Contains(trainNo)
                        select new
                        {
                            trip,
                            route,
                            trainType.TrainTypeDescArb,
                            Station1NameArb = station1.NameArb,
                            Station1NameEngl = station1.NameEngl,
                            Station2NameArb = station2.NameArb,
                            Station2NameEngl = station2.NameEngl,
                            Class1AName = class1.ClassAName,
                            Class2AName = class2.ClassAName
                        };

            var resultList = query.ToList();

            var groupedResults = resultList
                .GroupBy(r => new { r.trip.TrainNo, r.TrainTypeDescArb, r.trip.ClassCode1, r.trip.ClassCode2, r.trip.Saturday, r.trip.Sunday, r.trip.Monday, r.trip.Tuesday, r.trip.Wednesday, r.trip.Thursday, r.trip.Friday, r.Station1NameArb, r.Station1NameEngl, r.Station2NameArb, r.Station2NameEngl, r.trip.StartStation, r.trip.FinalStation, r.Class1AName, r.Class2AName })
                .Select(g => new TrainDisplayInfoViewModel
                {
                    TrainNo = g.Key.TrainNo,
                    TrainType = g.Key.TrainTypeDescArb,
                    ClassCode1 = g.Key.ClassCode1,
                    ClassCode2 = g.Key.ClassCode2,
                    Saturday = g.Key.Saturday,
                    Sunday = g.Key.Sunday,
                    Monday = g.Key.Monday,
                    Tuesday = g.Key.Tuesday,
                    Wednesday = g.Key.Wednesday,
                    Thursday = g.Key.Thursday,
                    Friday = g.Key.Friday,
                    TripNameArb = g.Key.Station1NameArb + " - " + g.Key.Station2NameArb,
                    TripNameEn = g.Key.Station1NameEngl + " - " + g.Key.Station2NameEngl,
                    StartStation = g.Key.StartStation,
                    FinalStation = g.Key.FinalStation,
                    ClassAName1 = g.Key.Class1AName,
                    ClassAName2 = g.Key.Class2AName,
                    TrainDisplayInfoDetails = g.Select(r => new TrainDisplayInfoDetailsViewModel
                    {
                        StationCode = r.route.StationCode,
                        NameArb = _context.stations.FirstOrDefault(s => s.StationCode == r.route.StationCode).NameArb,
                        ArrivalTime = r.route.ArrivalTime,
                        DeptTime = r.route.DeptTime,
                        OrderNumber = r.route.OrderNumber,
                        PlateformNo = r.route.PlateformNo
                    }).ToList()
                }).ToList();

            return groupedResults;
        }
    }
}
