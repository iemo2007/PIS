using PIS.DAL;
using PIS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class TrainTypeManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainTypeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainTypeViewModel> GetAll()
        {
            return _unitOfWork.Train_Type.GetAll().Select(x => new TrainTypeViewModel()
            {
                audDateLastChanged = x.audDateLastChanged,
                LastModified = x.LastModified,
                TrainType = x.TrainType.Trim(),
                TrainTypeDescArb = x.TrainTypeDescArb.Trim(),
                TrainTypeDescEngl = x.TrainTypeDescEngl.Trim()
            });
        }
    }
}
