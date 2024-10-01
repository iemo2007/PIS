using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class Train_TripRepository : Repository<Train_Trip>, ITrain_TripRepository
    {
        public PISContext _context { get; }
        public Train_TripRepository(PISContext context) : base(context)
        {
            _context = context;
        }

        public List<SP_GetTrainDisplayInfo_Result> SP_GetTrainDisplayInfo(string trainNo)
        {
            var result = (from ttr in _context.TrainTripRouts
                          join s in _context.stations on ttr.StationCode equals s.StationCode
                          join tt in _context.Train_Trip on ttr.TrainNo equals tt.TrainNo
                          join trainClass in _context.Classes on tt.ClassCode1 equals trainClass.ClassCode
                          join trainClass2 in _context.Classes on tt.ClassCode2 equals trainClass2.ClassCode
                          join trainType in _context.Train_Type on tt.TrainType equals trainType.TrainType
                          where ttr.TrainNo == trainNo
                          orderby ttr.OrderNumber
                          select new SP_GetTrainDisplayInfo_Result
                          {
                              TrainNo = ttr.TrainNo,
                              StationCode = ttr.StationCode,
                              NameArb = s.NameArb,
                              ArrivalTime = ttr.ArrivalTime,
                              DeptTime = ttr.DeptTime,
                              OrderNumber = ttr.OrderNumber,
                              PlateformNo = ttr.PlateformNo,
                              TrainType = tt.TrainType,
                              ClassCode1 = tt.ClassCode1,
                              ClassCode2 = tt.ClassCode2,
                              Saturday = tt.Saturday,
                              Sunday = tt.Sunday,
                              Monday = tt.Monday,
                              Tuesday = tt.Tuesday,
                              Wednesday = tt.Wednesday,
                              Thursday = tt.Thursday,
                              Friday = tt.Friday,
                              ClassAName1 = trainClass.ClassAName,
                              ClassAName2 = trainClass2.ClassAName,
                              TrainTypeName = trainType.TrainTypeDescArb
                          }).ToList();

            return result;
        }

        public void ResetTrainTripTableTrainNumber(string trainNo)
        {
            var trainNoParam = new SqlParameter("@TrainNo", trainNo);
            _context.Database.ExecuteSqlRaw("EXEC Reset_Train_Trip_Table_TrainNumber @TrainNo", trainNoParam);
        }

        public void ResetTrainTripTable(string trainNo)
        {
            // Delete from Train_Trip
            var trainTripsToDelete = _context.Train_Trip.Where(tt => tt.TrainNo == trainNo);
            _context.Train_Trip.RemoveRange(trainTripsToDelete);
            _context.SaveChanges();
        }

        public void InsertIntoTrainTrip(string trainNo)
        {
            var trainTrips = (from ttr1 in _context.TrainTripRouts
                              join ttr2 in _context.TrainTripRouts on ttr1.TrainNo equals ttr2.TrainNo
                              where ttr1.OrderNumber == 1
                              && ttr1.TrainNo == trainNo
                              && ttr2.OrderNumber == _context.TrainTripRouts
                                                          .Where(x => x.TrainNo == ttr2.TrainNo)
                                                          .Max(x => x.OrderNumber)
                              select new Train_Trip
                              {
                                  TrainNo = ttr1.TrainNo,
                                  StartStation = ttr1.StationCode,
                                  DepartureTime = ttr1.DeptTime/*.ToString("HH:mm:ss")*/,
                                  FinalStation = ttr2.StationCode,
                                  ArrivalTime = ttr2.ArrivalTime/*.ToString("HH:mm:ss")*/
                              }).Distinct();

            _context.Train_Trip.AddRange(trainTrips);
            _context.SaveChanges();
        }

        public void InsertIntoSchedule(string trainNo)
        {
            var schedules = (from ttr in _context.TrainTripRouts
                             join tt in _context.Train_Trip on ttr.TrainNo equals tt.TrainNo
                             join s in _context.stations on ttr.StationCode equals s.StationCode
                             join s1 in _context.stations on tt.StartStation equals s1.StationCode
                             join s2 in _context.stations on tt.FinalStation equals s2.StationCode
                             join c1 in _context.Classes on tt.ClassCode1 equals c1.ClassCode
                             join c2 in _context.Classes on tt.ClassCode2 equals c2.ClassCode
                             join ttype in _context.Train_Type on tt.TrainType equals ttype.TrainType
                             where tt.TrainNo == trainNo
                             select new Schedule
                             {
                                 TrainNo = ttr.TrainNo,
                                 CurrentStation = ttr.StationCode,
                                 ArrivalTime = ttr.ArrivalTime,
                                 DeptTime = ttr.DeptTime,
                                 StartStationCode = tt.StartStation,
                                 FinalStationCode = tt.FinalStation,
                                 E_Journy = s1.NameEngl + " - " + s2.NameEngl,
                                 A_Journy = s1.NameArb + " - " + s2.NameArb,
                                 PlateformNo = ttr.PlateformNo,
                                 Class0Code = c1.ClassCode,
                                 Class0EName = c1.ClassEName,
                                 Class0AName = c1.ClassAName,
                                 Class1Code = c2.ClassCode,
                                 Class1EName = c2.ClassEName,
                                 Class1AName = c2.ClassAName,
                                 TrainTypeCode = ttype.TrainType,
                                 TrainTypeEName = ttype.TrainTypeDescEngl,
                                 TrainTypeAName = ttype.TrainTypeDescArb,
                                 StationOrder = ttr.OrderNumber,
                                 Saturday = tt.Saturday,
                                 Sunday = tt.Sunday,
                                 Monday = tt.Monday,
                                 Tuesday = tt.Tuesday,
                                 Wednesday = tt.Wednesday,
                                 Thursday = tt.Thursday,
                                 Friday = tt.Friday
                             }).Distinct();

            _context.Schedules.AddRange(schedules);
            _context.SaveChanges();
        }
    }
}
