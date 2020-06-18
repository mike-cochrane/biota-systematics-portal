using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Web.Model.Interfaces;

namespace SystematicsPortal.Data
{
    public class NamesWebRepository : INamesWebRepository
    {
        private readonly NamesWebContext _context;


        public NamesWebRepository(NamesWebContext context)
        {
            _context = context;
        }
    }
}
