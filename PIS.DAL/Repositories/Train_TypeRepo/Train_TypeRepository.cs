using PIS.DAL.Repositories.GenericRepo;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.Train_TypeRepo
{
    public class Train_TypeRepository : Repository<Train_Type>, ITrain_TypeRepository
    {
        public PISContext _context { get; }
        public Train_TypeRepository(PISContext context) : base(context)
        {
            _context = context;
        }
    }
}
