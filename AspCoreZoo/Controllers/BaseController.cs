using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreZoo.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ZooContext _context;

        public BaseController(ZooContext db_context): base()
        {
            _context = db_context;
        }
    }
}
