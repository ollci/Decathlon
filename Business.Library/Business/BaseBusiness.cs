using Entity.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library
{
    public class BaseBusiness
    {
        public DecathlonDbContext _context = null;
        public BaseBusiness(DecathlonDbContext dbEntities)
        {
            _context = dbEntities;
        }
    }
}
