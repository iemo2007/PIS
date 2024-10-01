using Microsoft.EntityFrameworkCore.Metadata;
using PIS.DAL;
using PIS.Models;
using PIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class TrainStatusManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainStatusManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainStatusViewModel> GetAllTrainStatuses()
        {

            List<TrainStatusViewModel> AllTrainStatuses = _unitOfWork.Train_Status.GetAll().Select(x => new TrainStatusViewModel
            {
                audDateLastChanged = x.audDateLastChanged,
                LastModified = x.LastModified,
                StatusEnSymbol = x.StatusEnSymbol,
                StatusID = x.StatusID,
                StatusName = x.StatusName,
                StatusSymbol = x.StatusSymbol
            }).ToList();
         
            return AllTrainStatuses;
        }

        public TrainStatusViewModel GetById(string id)
        {
            var obj = _unitOfWork.Train_Status.GetAll().FirstOrDefault(r => r.StatusID.ToString() == id);
            return new TrainStatusViewModel
            {
                StatusID = obj.StatusID,
                StatusName = obj.StatusName,
                StatusSymbol = obj.StatusSymbol,
                StatusEnSymbol = obj.StatusEnSymbol
            };
        }

        public decimal AddEdit(TrainStatusViewModel obj)
        {
            var status = _unitOfWork.Train_Status.GetAll().FirstOrDefault(r => r.StatusID.ToString() == obj.StatusID.ToString());

            if (status == null)
            {
                status = new Train_Status()
                {
                    StatusName = obj.StatusName,
                    StatusSymbol = obj.StatusSymbol,
                    StatusEnSymbol = obj.StatusEnSymbol,
                    LastModified = DateTime.Now
                };

                _unitOfWork.Train_Status.Add(status);
            }
            else
            {
                status.StatusName = obj.StatusName;
                status.StatusSymbol = obj.StatusSymbol;
                status.StatusEnSymbol = obj.StatusEnSymbol;
                status.LastModified = DateTime.Now;

                _unitOfWork.Train_Status.update(status);
            }

            bool added = _unitOfWork.Complete();
            if (added) return status.StatusID;
            else return -1;
        }

        public bool DeleteTrainStatus(int statusID)
        {
            Train_Status obj = _unitOfWork.Train_Status.Get(statusID);

            if(obj == null)
                throw new Exception("الحالة التى تريد حذفها غير موجودة");

            _unitOfWork.Train_Status.Delete(obj);
            bool isRemoved = _unitOfWork.Complete();

            if (obj == null)
                throw new Exception("لم يتم الحذف");

            return true;
        }
    }
}
