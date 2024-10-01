using PIS.DAL;
using PIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class TrainClassManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainClassManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainClassViewModel> GetAll()
        {
            return _unitOfWork.Classes.GetAll().Select(x => new TrainClassViewModel()
            {
                ClassAName = x.ClassAName.Trim(),
                audDateLastChanged = x.audDateLastChanged,
                ClassCode = x.ClassCode.Trim(),
                ClassEName = x.ClassEName.Trim(),
                LastModified = x.LastModified
            });
        }
    }
}
