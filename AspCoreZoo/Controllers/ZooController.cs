using System;
using System.Collections.Generic;
using System.Linq;
using ZooLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooController : BaseController
    {
        public ZooController(ZooContext db_context) : base(db_context) { }

        // GET: api/<controller>
        [HttpGet]
        [HttpPost]
//        public IEnumerable<Animal> Get() => _context.Animals.AsEnumerable();
        
        public string Get()
        {
            return JsonConvert.SerializeObject(
                        _context.Animals.AsEnumerable(), 
                        new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    }
            );
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [HttpPost("{id}")]
        public Animal Get(int id)
        {
            return _context.Animals.Where(o => o.Id == id).FirstOrDefault();
        }

    }
}
