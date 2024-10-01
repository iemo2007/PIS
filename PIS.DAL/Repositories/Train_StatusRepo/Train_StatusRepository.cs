using PIS.DAL.Repositories.GenericRepo;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.Train_StatusRepo
{
    public class Train_StatusRepository : Repository<Train_Status>, ITrain_StatusRepository
    {
        public PISContext _context { get; }
        public Train_StatusRepository(PISContext context) : base(context)
        {
            _context = context;
        }
    }
}
