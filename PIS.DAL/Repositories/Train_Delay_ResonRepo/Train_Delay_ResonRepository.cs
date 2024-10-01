using PIS.DAL.Repositories.GenericRepo;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.Train_Delay_ResonRepo
{
    public class Train_Delay_ResonRepository : Repository<Train_Delay_Reson>, ITrain_Delay_ResonRepository
    {
        public PISContext _context { get; }
        public Train_Delay_ResonRepository(PISContext context) : base(context)
        {
            _context = context;
        }
    }
}
