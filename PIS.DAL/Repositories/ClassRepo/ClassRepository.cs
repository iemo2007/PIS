using PIS.DAL.Repositories.GenericRepo;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.ClassRepo
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public PISContext _context { get; }
        public ClassRepository(PISContext context) : base(context)
        {
            _context = context;
        }
    }
}
