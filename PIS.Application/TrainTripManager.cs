using Microsoft.EntityFrameworkCore;
using PIS.DAL;
using PIS.DTO;
using PIS.Models;
using PIS.ViewModels.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PIS.Application
{
    public class TrainTripManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainTripManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainTripViewModel> GetAllTrainTrips()
        {
            return _unitOfWork.Train_Trip.GetAll().Select(x => new TrainTripViewModel
            {
                TrainNo = x.TrainNo.Trim()
            });
        }

        public string AddTrain(TrainTripViewModel objTrain)
        {
            Train_Trip trainTrip = new Train_Trip
            {
                TrainNo = objTrain.TrainNo,
                StartStation = objTrain.StartStationCode,
                FinalStation = objTrain.EndStationCode,
                DepartureTime = new DateTime(1900, 1, 1),
                ArrivalTime = new DateTime(1900, 1, 1).AddHours(1)
            };

            _unitOfWork.Train_Trip.Add(trainTrip);
            var added = _unitOfWork.Complete();
            if (added) return trainTrip.TrainNo;
            else return null;
        }

        public bool CheckTrainExistance(string trainNo)
        {
            var dbObj = _unitOfWork.TrainTripRouts.GetAll().FirstOrDefault(x => x.TrainNo == trainNo);
            return dbObj != null;
        }

        public List<TrainsTripRouteDTO> GetTrainsTripRoutes(string trainNo)
        {
            var stations = _unitOfWork.stations.GetAll();
            Dictionary<string, string> stationsByCode = new Dictionary<string, string>();
            foreach (var station in stations)
            {
                if (!stationsByCode.ContainsKey(station.StationCode.Trim()))
                    stationsByCode.Add(station.StationCode.Trim(), station.NameArb);
            }

            //var res = _unitOfWork.TrainTripRouts.GetAll().Where(r => r.TrainNo == trainNo).ToList();
            //var resdto = new List<TrainsTripRouteDTO>();
            //foreach (var x in res)
            //{
            //    var it = new TrainsTripRouteDTO();
            //    it.TrainNo = x.TrainNo.Trim();
            //    it.StationCode = x.StationCode.Trim();
            //    if (stationsByCode.ContainsKey(x.StationCode.Trim()))
            //        it.StationName = stationsByCode[x.StationCode.Trim()];
            //    else
            //        it.StationName = "";
            //    // it.StationName = stationsByCode.ContainsKey(x.StationCode) ? stationsByCode[x.StationCode] : "";
            //    it.ArrivalTime = x.ArrivalTime.ToString("HH:mm");
            //    it.DepartureTime = x.DeptTime.ToString("HH:mm");
            //    it.Order = x.OrderNumber.HasValue ? x.OrderNumber.ToString() : "0";
            //    it.PlatformNumber = string.IsNullOrWhiteSpace(x.PlateformNo) ? "" : x.PlateformNo;
            //}

            return _unitOfWork.TrainTripRouts.GetAll().Where(r => r.TrainNo == trainNo).ToList().Select(x => new TrainsTripRouteDTO
            {
                TrainNo = x.TrainNo.Trim(),
                StationCode = x.StationCode.Trim(),
                StationName = stationsByCode.ContainsKey(x.StationCode.Trim()) ? stationsByCode[x.StationCode.Trim()] : "",
                ArrivalTime = x.ArrivalTime.ToString("HH:mm"),
                DepartureTime = x.DeptTime.ToString("HH:mm"),
                Order = x.OrderNumber.HasValue ? x.OrderNumber.ToString() : "0",
                PlatformNumber = string.IsNullOrWhiteSpace(x.PlateformNo) ? "" : x.PlateformNo
            }).OrderBy(tr => int.Parse(tr.Order)).ToList();
        }

        //public void UpdateTrainsTripRoutes(string trainNo, List<TrainTripViewModel> trainStations)
        //{

        //    var listToInsert = trainStations.Select(t => new TrainTripRout
        //    {
        //        TrainNo = t.TrainNo,
        //        StationCode = t.StationCode,
        //        ArrivalTime = DateTime.ParseExact("01/01/1900 " + t.ArrivalTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
        //        DeptTime = DateTime.ParseExact("01/01/1900 " + t.DepartureTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
        //        OrderNumber = double.Parse(t.Order),
        //        PlateformNo = t.PlatformNumber,
        //        LastModified = DateTime.Now
        //    }).ToList();

        //    var oldTrainStations = _unitOfWork.TrainTripRouts.GetAll().Where(t => t.TrainNo == trainNo);
        //    _unitOfWork.TrainTripRouts.RemoveRange(oldTrainStations);

        //    var oldSchedules = _unitOfWork.Schedules.GetAll().Where(t => t.TrainNo == trainNo);
        //    _unitOfWork.Schedules.RemoveRange(oldSchedules);

        //    _unitOfWork.TrainTripRouts.AddRange(listToInsert);

        //    //context.SaveChanges();
        //    // context.Reset_Train_Trip_Table_TrainNumber(trainNo);

        //    Train_Trip trainTripToBeRemoved = _unitOfWork.Train_Trip.FilterFirst(tt => tt.TrainNo == trainNo);
        //    _unitOfWork.Train_Trip.Delete(trainTripToBeRemoved);


        //    double? lastStationNumber = _unitOfWork.TrainTripRouts.GetAll().Where(ttr => ttr.TrainNo == trainNo).Max(ttr => ttr.OrderNumber);
        //    TrainTripRout startStation = _unitOfWork.TrainTripRouts.FilterFirst(ttr => ttr.TrainNo == trainNo && ttr.OrderNumber == 1);
        //    TrainTripRout finalStation = _unitOfWork.TrainTripRouts.FilterFirst(ttr => ttr.TrainNo == trainNo && ttr.OrderNumber == lastStationNumber);

        //    Train_Trip newTrainTrip = new Train_Trip
        //    {
        //        TrainNo = trainNo,
        //        StartStation = startStation.StationCode,
        //        DepartureTime = startStation.DeptTime,
        //        FinalStation = finalStation.StationCode,
        //        ArrivalTime = finalStation.ArrivalTime,
        //    };

        //    List<Schedule> newSchedules = _unitOfWork.TrainTripRouts.GetAll()
        //        .Where(ttr => ttr.TrainNo!= trainNo)
        //        .Select(ttr => new Schedule 
        //        {
        //            TrainNo = trainNo,
        //            CurrentStation = ttr.StationCode,
        //            ArrivalTime = ttr.ArrivalTime,
        //            DeptTime= ttr.DeptTime,
        //            StartStationCode= ttr.Train_Trip.StartStation,
        //            FinalStationCode = ttr.Train_Trip.FinalStation,
        //            E_Journy = $"{ttr.Train_Trip.StartStationObj.NameEngl} - {ttr.Train_Trip.FinalStationObj.NameEngl}",
        //            A_Journy = $"{ttr.Train_Trip.StartStationObj.NameArb} - {ttr.Train_Trip.FinalStationObj.NameArb}",
        //            PlateformNo = ttr.PlateformNo,
        //            Class0Code = ttr.Train_Trip.Class1.ClassCode,
        //            Class0EName = ttr.Train_Trip.Class1.ClassEName,
        //            Class0AName = ttr.Train_Trip.Class1.ClassAName,
        //            Class1Code = ttr.Train_Trip.Class2.ClassCode,
        //            Class1EName = ttr.Train_Trip.Class2.ClassEName,
        //            Class1AName = ttr.Train_Trip.Class2.ClassAName,
        //            TrainTypeCode = ttr.Train_Trip.Train_Type.TrainType,
        //            TrainTypeEName = ttr.Train_Trip.Train_Type.TrainTypeDescEngl,
        //            TrainTypeAName = ttr.Train_Trip.Train_Type.TrainTypeDescArb,
        //            StationOrder = ttr.OrderNumber,
        //            Saturday = ttr.Train_Trip.Saturday,
        //            Sunday = ttr.Train_Trip.Sunday,
        //            Monday = ttr.Train_Trip.Monday,
        //            Tuesday = ttr.Train_Trip.Tuesday,
        //            Wednesday = ttr.Train_Trip.Wednesday,
        //            Thursday = ttr.Train_Trip.Thursday,
        //            Friday = ttr.Train_Trip.Friday,
        //        }).ToList();

        //    _unitOfWork.Schedules.AddRange(newSchedules);
        //    _unitOfWork.Complete();
        //}

        public void UpdateTrainsTripRoutes(string trainNo, List<TrainsTripRouteDTO> trainStations)
        {
            string trimmedTrainNo = trainNo.Trim();
            var listToInsert = trainStations.Select(t => new TrainTripRout
            {
                TrainNo = t.TrainNo,
                StationCode = t.StationCode,
                ArrivalTime = DateTime.ParseExact("01/01/1900 " + $"{t.ArrivalTime}:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                DeptTime = DateTime.ParseExact("01/01/1900 " + $"{t.DepartureTime}:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                OrderNumber = double.Parse(t.Order),
                PlateformNo = t.PlatformNumber,
                LastModified = DateTime.Now
            }).ToList();

            var oldTrainStations = _unitOfWork.TrainTripRouts.GetAll().Where(t => t.TrainNo == trainNo);
            _unitOfWork.TrainTripRouts.RemoveRange(oldTrainStations);

            var oldSchedules = _unitOfWork.Schedules.GetAll().Where(t => t.TrainNo.Trim() == trimmedTrainNo);
            _unitOfWork.Schedules.RemoveRange(oldSchedules);

            _unitOfWork.TrainTripRouts.AddRange(listToInsert);

            _unitOfWork.Complete();

            // Reset_Train_Trip_Table_TrainNumber(trainNo);
            _unitOfWork.Train_Trip.ResetTrainTripTableTrainNumber(trimmedTrainNo);

            // _unitOfWork.Complete(); // Save reset operations
        }

        public void Reset_Train_Trip_Table_TrainNumber(string trainNo)
        {
            _unitOfWork.Train_Trip.ResetTrainTripTable(trainNo);
            _unitOfWork.Train_Trip.InsertIntoTrainTrip(trainNo);
            _unitOfWork.Train_Trip.InsertIntoSchedule(trainNo);
        }

        public void DeleteTrainTime(string trainNo, string startStation, string finalStation)
        {             
            var trainTrips = _unitOfWork.Train_Trip.GetAll().Where(t => t.TrainNo.Trim() == trainNo.Trim() && t.StartStation.Trim() == startStation.Trim() && t.FinalStation.Trim() == finalStation.Trim());
            _unitOfWork.Train_Trip.RemoveRange(trainTrips);

            var routes = _unitOfWork.TrainTripRouts.GetAll().Where(t => t.TrainNo.Trim() == trainNo.Trim());
            _unitOfWork.TrainTripRouts.RemoveRange(routes);

            var oldSchedules = _unitOfWork.Schedules.GetAll().Where(t => t.TrainNo.Trim() == trainNo.Trim());
            _unitOfWork.Schedules.RemoveRange(oldSchedules);
            _unitOfWork.Complete();
                
                //context.SaveChanges();
                //scope.Complete();            
        }

        public List<TrainDisplayInfoViewModel> GetTrainTimes(string trainNo, string stationCode)
        {
            List<TrainDisplayInfoViewModel> trainTimes = _unitOfWork.TrainTripRouts.SP_GetTrainTimes(trainNo, stationCode);
            return trainTimes;
        }

        public TrainDisplayInfoViewModel GetDisplayTrainInfo(string strTrainNo)
        {
            // TrainDisplayInfoViewModel trainDisplayInfo = _unitOfWork.TrainTripRouts.GetDisplayTrainInfo(strTrainNo);


            var objTrainTrips = _unitOfWork.Train_Trip.SP_GetTrainDisplayInfo(strTrainNo.Trim());

            TrainDisplayInfoViewModel objModel = new TrainDisplayInfoViewModel();


            if (objTrainTrips != null)
            {
                var _list = objTrainTrips.ToList();

                if (_list.Count <= 0)
                {
                    return objModel;
                }
                objModel.TrainNo = _list[0].TrainNo.Trim();
                objModel.ClassCode1 = _list[0].ClassCode1.Trim();
                objModel.ClassCode2 = _list[0].ClassCode2.Trim();
                objModel.Friday = _list[0].Friday;
                objModel.Monday = _list[0].Monday;
                objModel.Saturday = _list[0].Saturday;
                objModel.Sunday = _list[0].Sunday;
                objModel.Thursday = _list[0].Thursday;
                objModel.TrainType = _list[0].TrainType.Trim();
                objModel.Tuesday = _list[0].Tuesday;
                objModel.Wednesday = _list[0].Wednesday;
                objModel.ClassAName1 = _list[0].ClassAName1;
                objModel.ClassAName2 = _list[0].ClassAName2;
                objModel.TrainTypeName = _list[0].TrainTypeName;
                objModel.TrainDisplayInfoDetails = new List<TrainDisplayInfoDetailsViewModel>();
                foreach (var item in _list)
                {
                    objModel.TrainDisplayInfoDetails.Add(new TrainDisplayInfoDetailsViewModel()
                    {
                        ArrivalTime = item.ArrivalTime,
                        DeptTime = item.DeptTime,
                        NameArb = item.NameArb,
                        OrderNumber = item.OrderNumber,
                        PlateformNo = item.PlateformNo,
                        StationCode = item.StationCode
                    });
                }
            }

            return objModel;
        }

        public bool UpdateTrainTrip(UpdateTrainTripRequest model, string strCurrentStation)
        {
            // Query = "Update [Train_Trip] SET ClassCode1 = '" + TrainClass1.SelectedValue.ToString().Trim() + "', 
            //ClassCode2 = '" + TrainClass2.SelectedValue.ToString().Trim() + "', 
            //TrainType ='" + TrainType.SelectedValue.ToString().Trim() + "' WHERE TrainNo='" + Train_Number + "' ;";

            if (string.IsNullOrWhiteSpace(model.TrainNo)) return false;
            else
            {

                var objTrainTrip = _unitOfWork.Train_Trip.FilterFirst(x => x.TrainNo.Trim() == model.TrainNo.Trim());
                var objTrainSchedule = _unitOfWork.Schedules.FilterFirst(x => x.TrainNo.Trim() == model.TrainNo.Trim() && x.CurrentStation.Trim() == strCurrentStation.Trim());

                if (objTrainTrip == null || objTrainSchedule == null)
                {
                    return false;
                }
                else
                {
                    //objTrainTrip.ClassCode1 = model.ClassCode1;
                    //objTrainTrip.ClassCode2 = model.ClassCode2;
                    //objTrainTrip.TrainType = model.TrainType;


                    objTrainTrip.Saturday = model.Saturday;
                    objTrainTrip.Sunday = model.Sunday;
                    objTrainTrip.Monday = model.Monday;
                    objTrainTrip.Tuesday = model.Tuesday;
                    objTrainTrip.Wednesday = model.Wednesday;
                    objTrainTrip.Thursday = model.Thursday;
                    objTrainTrip.Friday = model.Friday;

                    objTrainSchedule.Saturday = model.Saturday;
                    objTrainSchedule.Sunday = model.Sunday;
                    objTrainSchedule.Monday = model.Monday;
                    objTrainSchedule.Tuesday = model.Tuesday;
                    objTrainSchedule.Wednesday = model.Wednesday;
                    objTrainSchedule.Thursday = model.Thursday;
                    objTrainSchedule.Friday = model.Friday;

                    // TrainScheduleManager.ResetCacheTriggered = true;
                    _unitOfWork.Train_Trip.update(objTrainTrip);
                    _unitOfWork.Schedules.update(objTrainSchedule);
                    return _unitOfWork.Complete();
                }
               
            }

        }
    }
}
