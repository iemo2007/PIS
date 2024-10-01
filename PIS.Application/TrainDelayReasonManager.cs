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
    public class TrainDelayReasonManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainDelayReasonManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainDelayReasonViewModel> GetAllTrainDelayReasons()
        {

            List<TrainDelayReasonViewModel> AllTrainDelayReasons = _unitOfWork.Train_Delay_Reson.GetAll().Select(x => new TrainDelayReasonViewModel
            {
                ResonID = x.ResonID,
                ResonName = x.ResonName,
                audDateLastChanged = x.audDateLastChanged,
                LastModified = x.LastModified
            }).ToList();
            return AllTrainDelayReasons;
        }

        public TrainDelayReasonViewModel GetTrainDelayReasonsById(string id)
        {
            var reason = _unitOfWork.Train_Delay_Reson.GetAll().FirstOrDefault(r => r.ResonID.ToString() == id);

            return new TrainDelayReasonViewModel
            {
                ResonID = reason.ResonID,
                ResonName = reason.ResonName,
                audDateLastChanged = reason.audDateLastChanged,
                LastModified = reason.LastModified
            };
        }

        public decimal AddEditDelayReason(TrainDelayReasonViewModel objReasonVM)
        {
            var reason = _unitOfWork.Train_Delay_Reson.FilterFirst(r => r.ResonID.ToString() == objReasonVM.ResonID.ToString());

            if (reason == null)
            {
                reason = new Train_Delay_Reson()
                {
                    ResonName = objReasonVM.ResonName,
                    audDateLastChanged = objReasonVM.audDateLastChanged,
                    LastModified = objReasonVM.LastModified
                };

                _unitOfWork.Train_Delay_Reson.Add(reason);
            }
            else
            {
                reason.ResonName = objReasonVM.ResonName;
                reason.LastModified = DateTime.Now;

                _unitOfWork.Train_Delay_Reson.update(reason);
            }
            var added = _unitOfWork.Complete();
            if (added) return reason.ResonID;
            else return -1;
        }

        public bool DeleteDelayReason(int resonID)
        {
            Train_Delay_Reson obj = _unitOfWork.Train_Delay_Reson.Get(resonID);

            if (obj == null)
                throw new Exception("سبب التأخير الذى تريد حذفه غير موجود");

            _unitOfWork.Train_Delay_Reson.Delete(obj);
            bool isRemoved = _unitOfWork.Complete();

            if (obj == null)
                throw new Exception("لم يتم الحذف");

            return true;
        }
    }
}
