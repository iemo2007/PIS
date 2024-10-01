using PIS.DAL;
using PIS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Application
{
    public class TrainTripRoutManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainTripRoutManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
    }
}
