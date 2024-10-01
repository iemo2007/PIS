using PIS.DAL;
using PIS.DAL.Repositories.GenericRepo;
using PIS.DTO;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class TrainScheduleManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainScheduleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TrainScheduleViewMode> AllTrainsSchedule
        {
            get
            {
                return GetAllTrainSchedules();
            }
            set
            {
                AllTrainsSchedule = value;
            }
        }

        public List<TrainScheduleViewMode> SearhTrainSchedules(TrainScheduleSearchFilter searchFilter)
        {

            List<TrainScheduleViewMode> viewModels = new List<TrainScheduleViewMode>();
            DateTime? arrivalTime = null, departureTime = null;
            if (!string.IsNullOrWhiteSpace(searchFilter.ArrivalTime))
            {
                arrivalTime = DateTime.Parse(searchFilter.ArrivalTime);
            }

            if (!string.IsNullOrWhiteSpace(searchFilter.DepartureTime))
            {
                departureTime = DateTime.Parse(searchFilter.DepartureTime);
            }
            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString().ToLower();
            //  var result = context.GetTrainsSchedules(searchFilter.TrainNo, searchFilter.CurrentStation, departureTime, departureTime, DateTime.Now.DayOfWeek.ToString(),
            //         searchFilter.EndPlatformNumber, searchFilter.StartStation, searchFilter.EndStation);

            var result = AllTrainsSchedule.Where(x => (searchFilter.TrainNo == null || x.TrainNo.Trim() == searchFilter.TrainNo.Trim() || searchFilter.TrainNo.Trim() == "")
                                    && (searchFilter.CurrentStation == null || x.CurrentStation.Trim() == searchFilter.CurrentStation.Trim() || searchFilter.CurrentStation.Trim() == "")
                                    && (!departureTime.HasValue || DateTime.Parse(x.DeptTime) >= departureTime.Value)
                                    && (!arrivalTime.HasValue || DateTime.Parse(x.ArrivalTime) <= arrivalTime.Value)
                                    && (searchFilter.EndPlatformNumber == null || searchFilter.EndPlatformNumber.Trim() == "" || x.PlateformNo.Trim() == searchFilter.EndPlatformNumber.Trim())
                                    && (searchFilter.StartStation == null || searchFilter.StartStation.Trim() == "" || searchFilter.StartStation.Trim() == "0" || x.StartStationCode.Trim() == searchFilter.StartStation.Trim())
                                    && (searchFilter.EndStation == null || searchFilter.EndStation.Trim() == "" || searchFilter.EndStation.Trim() == "0" || x.FinalStationCode.Trim() == searchFilter.EndStation.Trim())
                                    && (

                                             (dayOfTheWeek == "saturday" && x.Saturday == true)
                                             ||
                                             (dayOfTheWeek == "sunday" && x.Sunday == true)
                                             ||
                                             (dayOfTheWeek == "monday" && x.Monday == true)
                                             ||
                                             (dayOfTheWeek == "tuesday" && x.Tuesday == true)
                                             ||
                                             (dayOfTheWeek == "wednesday" && x.Wednesday == true)
                                             ||
                                             (dayOfTheWeek == "thursday" && x.Thursday == true)
                                             ||
                                             (dayOfTheWeek == "friday" && x.Friday == true)
                                          )

                                     );

            if (result != null)
            {
                foreach (var x in result.ToList())
                {
                    viewModels.Add(new TrainScheduleViewMode
                    {
                        TrainNo = x.TrainNo,
                        ArrivalTime = x.ArrivalTime,
                        A_Journy = x.A_Journy,
                        Class0AName = x.Class0AName,
                        Class1AName = x.Class1AName,
                        CurrentStation = x.CurrentStation,
                        DelayStatus = x.DelayStatus,
                        DeptTime = x.DeptTime,
                        PlateformNo = x.PlateformNo,
                        TrainTypeAName = x.TrainTypeAName,
                        DelayReason = x.DelayReason
                    });
                }
            }
            return viewModels;

        }

        public List<TrainScheduleViewMode> GetTrainsOfToday(int count, string stationCode, DateTime trainsDay, string dayOfTheWeek)
        {
            List<TrainScheduleViewMode> trainsOfToday = _unitOfWork.Schedules.GetTrainsOfToday(count, stationCode, trainsDay, dayOfTheWeek).ToList();
            return trainsOfToday;
        }

        public List<TrainScheduleViewMode> GetAllTrainSchedules()
        {
            //IQueryable<Schedule> _allDbScheduals;


            //_allDbScheduals = _unitOfWork.Schedules.GetAll().Distinct();

            //IQueryable<TrainTripRout> _allDbTrainTripRoutRep = _unitOfWork.TrainTripRouts.GetAll().Distinct();


            //List<TrainScheduleViewMode> allTrainSchedulesViewModels = new List<TrainScheduleViewMode>();

            //if (_allDbScheduals != null)
            //{
            //    foreach (var x in _allDbScheduals)
            //    {
            //        var trainTripRoutObj = _allDbTrainTripRoutRep.FirstOrDefault(t => t.TrainNo.Trim() == x.TrainNo.Trim());
            //        allTrainSchedulesViewModels.Add(new TrainScheduleViewMode
            //        {
            //            TrainNo = x.TrainNo,
            //            ArrivalTime = x.ArrivalTime.HasValue ? x.ArrivalTime.Value.ToString("HH:mm:ss") : "",
            //            audDateLastChanged = x.audDateLastChanged,
            //            A_Journy = x.A_Journy,
            //            Class0AName = x.Class0AName,
            //            Class0Code = x.Class0Code,
            //            Class0EName = x.Class0EName,
            //            Class1AName = x.Class1AName,
            //            Class1Code = x.Class1Code,
            //            Class1EName = x.Class1EName,
            //            CurrentStation = x.CurrentStation,
            //            DelayStatus = x.DelayStatus,
            //            DeptTime = x.DeptTime.HasValue ? x.DeptTime.Value.ToString("HH:mm:ss") : "",
            //            E_Journy = x.E_Journy,
            //            FinalStationCode = x.FinalStationCode,
            //            Friday = x.Friday,
            //            Modified = x.Modified,
            //            Monday = x.Monday,
            //            PlateformNo = x.PlateformNo,
            //            Saturday = x.Saturday,
            //            StartStationCode = x.StartStationCode,
            //            StationOrder = x.StationOrder,
            //            Sunday = x.Sunday,
            //            Thursday = x.Thursday,
            //            TrainTypeAName = x.TrainTypeAName,
            //            TrainTypeCode = x.TrainTypeCode,
            //            TrainTypeEName = x.TrainTypeEName,
            //            Tuesday = x.Tuesday,
            //            Wednesday = x.Wednesday,
            //            DelayReason = x.DelayReason,
            //            OrignalArrivalTime = trainTripRoutObj.ArrivalTime.ToString("HH:mm:ss"),
            //            OrignalDepatruteTime = trainTripRoutObj.DeptTime.ToString("HH:mm:ss")
            //        }); ;
            //    }
            //}

            List<TrainScheduleViewMode> allTrainSchedulesViewModels = _unitOfWork.Schedules.GetAllTrainSchedules();
            return allTrainSchedulesViewModels;      
        }

        public List<TrainScheduleViewMode> GetScheduleByTrainNumber(string strTrainNumber, string strCurrentStation)
        {
            List<TrainScheduleViewMode> allTrainsSchedus = GetAllTrainSchedules();

            if (allTrainsSchedus != null)
            {
                return allTrainsSchedus.Where(x => x.TrainNo.Trim() == strTrainNumber.Trim() && x.CurrentStation.Trim() == strCurrentStation.Trim()).ToList();
            }
            return new List<TrainScheduleViewMode>();

        }


        public bool DeletetScheduleByTrainNumber(string strTrainNumber)
        {
            IQueryable<Schedule> schedulesToBeRemoved = _unitOfWork.Schedules.GetAll().Where(s => s.TrainNo == strTrainNumber);
            _unitOfWork.Schedules.RemoveRange(schedulesToBeRemoved);
            bool isRemoved = _unitOfWork.Complete();
            return isRemoved;        
        }



        public bool AddUpdateTrainSchedule(TrainScheduleViewMode model, string strCurrentStation)
        {
            // Query = "Update [Train_Trip] SET ClassCode1 = '" + TrainClass1.SelectedValue.ToString().Trim() + "', ClassCode2 = '" + TrainClass2.SelectedValue.ToString().Trim() + "', TrainType='" + TrainType.SelectedValue.ToString().Trim() + "' WHERE TrainNo='" + Train_Number + "' ;";

            Schedule objTrainSchedule = null;
            if (model.IsNew)
            {//Add
                objTrainSchedule = new Schedule();
                objTrainSchedule.CurrentStation = strCurrentStation;
                objTrainSchedule.TrainNo = model.TrainNo;
            }
            else
            {  //update
                objTrainSchedule = _unitOfWork.Schedules.FilterFirst(s => s.TrainNo.Trim() == model.TrainNo.Trim() && s.CurrentStation.Trim() == strCurrentStation.Trim());
            }

            if (objTrainSchedule == null)
            {
                return false;
            }
            else
            {

                objTrainSchedule.ArrivalTime = string.IsNullOrWhiteSpace(model.ArrivalTime) ? objTrainSchedule.ArrivalTime : DateTime.Parse(model.ArrivalTime);
                objTrainSchedule.A_Journy = string.IsNullOrWhiteSpace(model.A_Journy) ? objTrainSchedule.A_Journy : model.A_Journy;
                objTrainSchedule.Class0AName = string.IsNullOrWhiteSpace(model.Class0AName) ? objTrainSchedule.Class0AName : model.Class0AName;
                objTrainSchedule.Class0Code = string.IsNullOrWhiteSpace(model.Class0Code) ? objTrainSchedule.Class0Code : model.Class0Code;
                objTrainSchedule.Class0EName = string.IsNullOrWhiteSpace(model.Class0EName) ? objTrainSchedule.Class0EName : model.Class0EName;
                objTrainSchedule.Class1AName = string.IsNullOrWhiteSpace(model.Class1AName) ? objTrainSchedule.Class1AName : model.Class1AName;
                objTrainSchedule.Class1Code = string.IsNullOrWhiteSpace(model.Class1Code) ? objTrainSchedule.Class1Code : model.Class1Code;
                objTrainSchedule.Class1EName = string.IsNullOrWhiteSpace(model.Class1EName) ? objTrainSchedule.Class1EName : model.Class1EName;
                objTrainSchedule.DelayReason = string.IsNullOrWhiteSpace(model.DelayReason) ? objTrainSchedule.DelayReason : model.DelayReason;
                objTrainSchedule.DelayStatus = string.IsNullOrWhiteSpace(model.DelayStatus) ? objTrainSchedule.DelayStatus : model.DelayStatus;
                objTrainSchedule.DeptTime = string.IsNullOrWhiteSpace(model.DeptTime) ? objTrainSchedule.DeptTime : DateTime.Parse(model.DeptTime);
                objTrainSchedule.PlateformNo = string.IsNullOrWhiteSpace(model.PlateformNo) ? objTrainSchedule.PlateformNo : model.PlateformNo;
                if (model.WithoutPlatform)
                {
                    objTrainSchedule.PlateformNo = "-";
                }

                AllTrainsSchedule = null;
                if (model.IsNew)
                {
                    _unitOfWork.Schedules.Add(objTrainSchedule);
                }
                _unitOfWork.Complete();
                return true;
            }

        }

        public void AddUpdateTrainSchedule2(TrainScheduleViewMode model, string strCurrentStation)
        {

            var objTrainSchedule = _unitOfWork.Schedules.FilterFirst(s => s.TrainNo.Trim() == model.TrainNo.Trim() && s.CurrentStation.Trim() == strCurrentStation.Trim());
            if (objTrainSchedule == null)
            {
                Schedule s = new Schedule
                {
                    TrainNo = model.TrainNo,
                    CurrentStation = strCurrentStation,
                    ArrivalTime = string.IsNullOrWhiteSpace(model.ArrivalTime) ? objTrainSchedule.ArrivalTime : DateTime.Parse(model.ArrivalTime),
                    DeptTime = string.IsNullOrWhiteSpace(model.DeptTime) ? objTrainSchedule.DeptTime : DateTime.Parse(model.DeptTime),
                    StartStationCode = model.StartStationCode,
                    FinalStationCode = model.FinalStationCode,
                    PlateformNo = string.IsNullOrWhiteSpace(model.PlateformNo) ? "-" : model.PlateformNo,
                    A_Journy = string.IsNullOrWhiteSpace(model.A_Journy) ? objTrainSchedule.A_Journy : model.A_Journy
                };

                _unitOfWork.Schedules.Add(s);
                // _unitOfWork.Complete();
            }
            else
            {

                objTrainSchedule.ArrivalTime = string.IsNullOrWhiteSpace(model.ArrivalTime) ? objTrainSchedule.ArrivalTime : DateTime.Parse(model.ArrivalTime);
                objTrainSchedule.DeptTime = string.IsNullOrWhiteSpace(model.DeptTime) ? objTrainSchedule.DeptTime : DateTime.Parse(model.DeptTime);
                objTrainSchedule.StartStationCode = model.StartStationCode;
                objTrainSchedule.FinalStationCode = model.FinalStationCode;
                objTrainSchedule.PlateformNo = string.IsNullOrWhiteSpace(model.PlateformNo) ? "-" : model.PlateformNo;
                objTrainSchedule.A_Journy = string.IsNullOrWhiteSpace(model.A_Journy) ? objTrainSchedule.A_Journy : model.A_Journy;

                _unitOfWork.Schedules.update(objTrainSchedule);
                // _unitOfWork.Complete();
            }
            _unitOfWork.Complete();
        }
    }
}
